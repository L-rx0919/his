import request from "@/utils/request";

const config BASE_URL = "/api/v1/his/config";

const configAPI = {
  /**
   * 新增
   *
   * @param data 字典表单数据
   */
   addConfing(data: DictForm) {
    return request({
      url: `${DICT_BASE_URL}`,
      method: "post",
      data: data,
    });
  },
};
