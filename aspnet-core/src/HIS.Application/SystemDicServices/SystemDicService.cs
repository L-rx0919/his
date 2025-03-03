using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;
using HIS.Utility;
namespace HIS.SystemDicServices
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class SystemDicService:ApplicationService
    {
        private readonly IRepository<SysDict> repositoryDict;
        private readonly IRepository<SysDictData> repositoryDictData;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache<List<SysDictListDto>> distributedCache;

        public SystemDicService(
            IRepository<SysDict> repositoryDict,
            IRepository<SysDictData> repositoryDictData,
            IMemoryCache memoryCache,
            IDistributedCache<List<SysDictListDto>> distributedCache
            )
        {
            this.repositoryDict = repositoryDict;
            this.repositoryDictData = repositoryDictData;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }


        /// <summary>
        /// 从缓存读取字典数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<SysDictListDto>> GetDictForCacheAsync()
        {
            #region MyRegion
            //在第一次读取的时候，缓存没有数据，从数据库把数据加载到缓存

            /*var key = "SysDictListDto";

            var cache = distributedCache.GetString(key);

            if (!string.IsNullOrWhiteSpace(cache))
            {
                return JsonConvert.DeserializeObject<List<SysDictListDto>>(cache);
            }
            else
            {
                var list = ObjectMapper.Map<List<SysDict>, List<SysDictListDto>>(await repositoryDict.ToListAsync());

                //存入缓存
                distributedCache.SetString(key, JsonConvert.SerializeObject(list));

                return list;
            }*/
            #endregion

            return await distributedCache.GetOrAddAsync(nameof(SystemDicService.GetDictForCacheAsync), async () =>
            {
                return ObjectMapper.Map<List<SysDict>, List<SysDictListDto>>(await repositoryDict.ToListAsync());
            });
        }




        /// <summary>
        /// 获取字典服务
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/v1/dict/list")]
        public async Task<APIResult<List<SysDictDto>>> GetAllAsync()
        {
            // Try to get cached data first
            if (!memoryCache.TryGetValue(nameof(SysDict), out List<SysDict> sysDicts) ||
                !memoryCache.TryGetValue(nameof(SysDictData), out List<SysDictData> sysDictDatas))
            {
                // Fetch from database if not in cache
                sysDicts = await repositoryDict.GetListAsync(m => m.Status == Status.Enabled);
                sysDictDatas = await repositoryDictData.GetListAsync(m => m.Status == Status.Enabled);

                // Cache the fetched data
                memoryCache.Set(nameof(SysDict), sysDicts);
                memoryCache.Set(nameof(SysDictData), sysDictDatas, new MemoryCacheEntryOptions { SlidingExpiration = TimeSpan.FromSeconds(10) });
            }

            // Map the SysDict to SysDictDto
            var dictDtos = ObjectMapper.Map<List<SysDict>, List<SysDictDto>>(sysDicts);

            // Create a dictionary for fast lookup of SysDictData by DictCode
            var sysDictDataLookup = sysDictDatas
                .Where(m => m.Status == Status.Enabled)
                .OrderBy(m => m.Sort)
                .GroupBy(m => m.DictCode)
                .ToDictionary(g => g.Key, g => ObjectMapper.Map<List<SysDictData>, List<SysDictDataDto>>(g.ToList()));

            // Populate SysDictDataDtos in SysDictDto
            foreach (var item in dictDtos)
            {
                if (sysDictDataLookup.TryGetValue(item.DictCode, out var dataDtos))
                {
                    item.SysDictDataDtos = dataDtos;
                }
            }

            return new APIResult<List<SysDictDto>>()
            {
                Code = CodeEnum.success,
                Data = dictDtos
            };
        }

        /// <summary>
        /// 字典分页
        /// </summary>
        /// <param name="pageAndQueryParamsDto"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/dict/page")]
        public async Task<APIResult<PageResultDto<SysDictListDto>>> GetSysDictList([FromQuery] PageAndQueryParamsDto pageAndQueryParamsDto)
        {
            var query = await repositoryDict.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(pageAndQueryParamsDto.Keywords), m => m.Name.Contains(pageAndQueryParamsDto.Keywords) || m.DictCode.Contains(pageAndQueryParamsDto.Keywords));

            return new APIResult<PageResultDto<SysDictListDto>>
            {
                Code = CodeEnum.success,
                Data = new PageResultDto<SysDictListDto>
                {
                    List = ObjectMapper.Map<List<SysDict>, List<SysDictListDto>>(query.ToList()),
                    Total = query.Count()
                }
            };
        }

        /// <summary>
        /// 新增字典
        /// </summary>
        /// <param name="sysDictListDto"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/dict")]
        public async Task<APIResult<SysDictListDto>> CreateAsync(SysDictListDto sysDictListDto)
        {
            if (await repositoryDict.AnyAsync(m => m.DictCode == sysDictListDto.DictCode))
            {
                return new APIResult<SysDictListDto>
                {
                    Code = CodeEnum.error,
                    Msg = "已存在该字典编码"
                };
            }

            await repositoryDict.InsertAsync(ObjectMapper.Map<SysDictListDto, SysDict>(sysDictListDto));

            //删除缓存
            memoryCache.Remove(nameof(SysDict));

            return new APIResult<SysDictListDto>
            {
                Code = CodeEnum.success,
                Data = sysDictListDto,
                Msg = "Success"
            };
        }

        /// <summary>
        /// 获取字典类型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/dict/{Id}/form")]
        public async Task<APIResult<SysDictListDto>> GetAsync([FromRoute] Guid Id)
        {
            var entity = await repositoryDict.FindAsync(m => m.Id == Id);
            return new APIResult<SysDictListDto>
            {
                Code = CodeEnum.success,
                Data = ObjectMapper.Map<SysDict, SysDictListDto>(entity)
            };
        }

        /// <summary>
        /// 更新字典类型
        /// </summary>
        /// <param name="sysDictListDto"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("/api/v1/dict/{Id}")]
        public async Task<APIResult<SysDictListDto>> UpdateAsync(SysDictListDto sysDictListDto, [FromRoute] Guid Id)
        {
            if (await repositoryDict.AnyAsync(m => m.DictCode == sysDictListDto.DictCode && m.Id != Id))
            {
                return new APIResult<SysDictListDto>
                {
                    Code = CodeEnum.error,
                    Msg = "已存在该字典编码"
                };
            }

            var entity = await repositoryDict.FindAsync(m => m.Id == Id);

            entity = ObjectMapper.Map<SysDictListDto, SysDict>(sysDictListDto, entity);

            await repositoryDict.UpdateAsync(entity);

            //删除缓存
            memoryCache.Remove(nameof(SysDict));

            return new APIResult<SysDictListDto>
            {
                Code = CodeEnum.success,
                Data = ObjectMapper.Map<SysDict, SysDictListDto>(entity)
            };
        }

        /// <summary>
        /// 删除字典类型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("/api/v1/dict/{Id}")]
        public async Task<APIResult<bool>> DeleteAsync([FromRoute] Guid Id)
        {
            try
            {
                await repositoryDict.DeleteAsync(m => m.Id == Id);

                //删除缓存
                memoryCache.Remove(nameof(SysDict));

                return new APIResult<bool>
                {
                    Code = CodeEnum.success,
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new APIResult<bool>
                {
                    Code = CodeEnum.success,
                    Data = false,
                    Msg = e.Message
                };
            }
        }

        /// <summary>
        /// 字典数据分页
        /// </summary>
        /// <param name="pageAndQueryParamsDto"></param>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/dict-data/page")]
        public async Task<APIResult<PageResultDto<SysDictDataListDto>>> GetSysDictDataList([FromQuery] PageAndQueryParamsDto pageAndQueryParamsDto, string dictCode)
        {
            var query = (await repositoryDictData.GetQueryableAsync()).Where(m => m.DictCode == dictCode);
            query = query.WhereIf(!string.IsNullOrWhiteSpace(pageAndQueryParamsDto.Keywords), m => m.Label.Contains(pageAndQueryParamsDto.Keywords) || m.Value.Contains(pageAndQueryParamsDto.Keywords));

            return new APIResult<PageResultDto<SysDictDataListDto>>
            {
                Code = CodeEnum.success,
                Data = new PageResultDto<SysDictDataListDto>
                {
                    List = ObjectMapper.Map<List<SysDictData>, List<SysDictDataListDto>>(query.OrderBy(m => m.Sort).ToList()),
                    Total = query.Count()
                }
            };
        }

        /// <summary>
        /// 新增字典数据
        /// </summary>
        /// <param name="sysDictDataListDto"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/dict-data")]
        public async Task<APIResult<SysDictDataListDto>> CreateSysDictDataAsync(SysDictDataListDto sysDictDataListDto)
        {
            if (await repositoryDictData.AnyAsync(m => m.Value == sysDictDataListDto.Value))
            {
                return new APIResult<SysDictDataListDto>
                {
                    Code = CodeEnum.error,
                    Msg = "已存在该字典值"
                };
            }

            await repositoryDictData.InsertAsync(ObjectMapper.Map<SysDictDataListDto, SysDictData>(sysDictDataListDto));

            //删除缓存
            memoryCache.Remove(nameof(SysDictData));

            return new APIResult<SysDictDataListDto>
            {
                Code = CodeEnum.success,
                Data = sysDictDataListDto,
                Msg = "Success"
            };
        }

        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/dict-data/{Id}/form")]
        public async Task<APIResult<SysDictDataListDto>> GetSysDictDataAsync([FromRoute] Guid Id)
        {
            var entity = await repositoryDictData.FindAsync(m => m.Id == Id);
            return new APIResult<SysDictDataListDto>
            {
                Code = CodeEnum.success,
                Data = ObjectMapper.Map<SysDictData, SysDictDataListDto>(entity)
            };
        }

        /// <summary>
        /// 更新字典数据
        /// </summary>
        /// <param name="sysDictDataListDto"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("/api/v1/dict-data/{Id}")]
        public async Task<APIResult<SysDictDataListDto>> UpdateSysDictDataAsync(SysDictDataListDto sysDictDataListDto, [FromRoute] Guid Id)
        {
            if (await repositoryDictData.AnyAsync(m => m.Value == sysDictDataListDto.Value && m.Id != Id))
            {
                return new APIResult<SysDictDataListDto>
                {
                    Code = CodeEnum.error,
                    Msg = "已存在该字典数据"
                };
            }

            var entity = await repositoryDictData.FindAsync(m => m.Id == Id);

            entity = ObjectMapper.Map(sysDictDataListDto, entity);

            await repositoryDictData.UpdateAsync(entity);

            //删除缓存
            memoryCache.Remove(nameof(SysDictData));

            return new APIResult<SysDictDataListDto>
            {
                Code = CodeEnum.success,
                Data = ObjectMapper.Map<SysDictData, SysDictDataListDto>(entity)
            };
        }

        /// <summary>
        /// 删除字典数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("/api/v1/dict-data/{Id}")]
        public async Task<APIResult<bool>> DeleteSysDictDataAsync([FromRoute] Guid Id)
        {
            try
            {
                await repositoryDictData.DeleteAsync(m => m.Id == Id);

                //删除缓存
                memoryCache.Remove(nameof(SysDictData));

                return new APIResult<bool>
                {
                    Code = CodeEnum.success,
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new APIResult<bool>
                {
                    Code = CodeEnum.success,
                    Data = false,
                    Msg = e.Message
                };
            }
        }

        [HttpGet]
        public async Task<List<SysDictData>> CacheQuery()
        {
            return await memoryCache.GetOrCreateAsync(nameof(CacheQuery), async entry => {
                return await repositoryDictData.GetListAsync(m => m.Status == Status.Enabled);
            });
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        public async Task<APIResult<bool>> InitData()
        {
            try
            {
                await repositoryDict.InsertAsync(new SysDict
                {
                    Name = "通知级别",
                    DictCode = "notice_type",
                    Status = Status.Enabled
                });

                await repositoryDictData.InsertManyAsync(new List<SysDictData>
         {
             new SysDictData
             {
                 Status  = Status.Enabled,
                 DictCode = "notice_type",
                 Label = "系统升级",
                 Value = "1",
                 Sort = 1,
                 TagType = TagType.Primary.EnumToDescription()
             },
             new SysDictData
             {
                 Status  = Status.Enabled,
                 DictCode = "notice_type",
                 Label = "系统维护",
                 Value = "2",
                 Sort = 2,
                 TagType = TagType.Primary.EnumToDescription()
             },
             new SysDictData
             {
                 Status  = Status.Enabled,
                 DictCode = "notice_type",
                 Label = "安全警告",
                 Value = "3",
                 Sort = 3,
                 TagType = TagType.Primary.EnumToDescription()
             },
             new SysDictData
             {
                 Status  = Status.Enabled,
                 DictCode = "notice_type",
                 Label = "假期通知",
                 Value = "4",
                 Sort = 4,
                 TagType = TagType.Primary.EnumToDescription()
             },
             new SysDictData
             {
                 Status  = Status.Enabled,
                 DictCode = "notice_type",
                 Label = "公司新闻",
                 Value = "5",
                 Sort = 5
             },
             new SysDictData
             {
                 Status  = Status.Enabled,
                 DictCode = "notice_type",
                 Label = "其他",
                 Value = "99",
                 Sort = 99,
                 TagType = TagType.Primary.EnumToDescription()
             }
         });
                return new APIResult<bool>
                {
                    Code = CodeEnum.success,
                    Data = true
                };
            }
            catch (Exception)
            {
                return new APIResult<bool>
                {
                    Code = CodeEnum.success,
                    Data = false
                };
            }

        }

        /// <summary>
        /// 根据字典编码获取字典数据
        /// </summary>
        /// <param name="dicCode"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/dict-data/{dicCode}/options")]
        public async Task<APIResult<List<SysDictDataDto>>> GetSysDicDataAsync([FromRoute] string dicCode)
        {
            var data = await repositoryDictData.GetListAsync(m => m.DictCode == dicCode);

            return new APIResult<List<SysDictDataDto>>
            {
                Code = CodeEnum.success,
                Data = ObjectMapper.Map<List<SysDictData>, List<SysDictDataDto>>(data)
            };
        }
    }
}
