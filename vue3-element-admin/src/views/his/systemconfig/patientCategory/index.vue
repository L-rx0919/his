<template>
  <el-button type="danger" @click="dialogVisible = true">新增病人性质</el-button>
  <el-button type="primary" @click="loadData">修改</el-button>

  <el-input v-model="searchValue" placeholder="请输入搜索内容" clearable style="width: 300px" @change="search" />

  <el-button type="primary" @click="loadData">搜索</el-button>

  <el-table :data="GetNatureofList" border style="width: 100%" @selection-change="handleSelectionChange">
    <el-table-column type="selection" width="55" />
    <el-table-column prop="natureofPatientName" label="患者性质" width="180" />
    <el-table-column prop="naturecode" label="编码" width="180" />
    <el-table-column prop="hospitallogo" label="门诊住院标志" width="180" />
    <el-table-column prop="natureTypeCard" label="性质类别卡" width="180" />
    <el-table-column prop="medicaltype" label="以保险标准" width="180" />
    <el-table-column prop="remarks" label="备注" width="180" />
    <el-table-column prop="creationTime" label="创建时间">
      <template #default="{ row }">
        <span>{{ row.creationTime.slice(0, 10) }}</span>
      </template>
    </el-table-column>
    <el-table-column label="操作" width="180">
      <template #default="{ row }">
        <el-button type="danger" @click="deleteRow(row.id)">删除</el-button>
      </template>
    </el-table-column>
  </el-table>

  <el-dialog v-model="dialogVisible" title="新建病人性质" width="500" draggable overflow>
    <span>基本信息</span>
    <el-form :model="from">
      <el-form-item label="性质名称：	">
        <el-input v-model="from.natureofPatientName" placeholder="请输入名称" clearable />
      </el-form-item>
      <el-form-item label="性质代码">
        <el-input v-model="from.naturecode" placeholder="请输入性质代码" clearable />
      </el-form-item>
      <el-form-item label="医保险种类型">
        <el-input v-model="from.typeinsurance" placeholder="请输入医保" clearable />
      </el-form-item>

      <el-form-item label="门诊住院标志">
        <el-select v-model="from.hospitallogo">
          <el-option label="通用" value="通用"></el-option>
          <el-option label="仅门诊" value="仅门诊"></el-option>
          <el-option label="仅住院" value="仅住院"></el-option>
          <el-option label="系统" value="系统"></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="状态">
        <el-select v-model="from.status">
          <el-option label="启用" value="启用"></el-option>
          <el-option label="停用" value="停用"></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="性质类别(卡)">
        <el-select v-model="from.natureTypeCard">
          <el-option label="自费" value="自费"></el-option>
          <el-option label="医保" value="医保"></el-option>
        </el-select>
      </el-form-item>

      <el-form-item label="医保交易类型">
        <el-select v-model="from.medicaltype">
          <el-option label="不交易" value="不交易"></el-option>
          <el-option label="普通交易" value="普通交易"></el-option>
          <el-option label="大病交易" value="大病交易"></el-option>
        </el-select>
      </el-form-item>
    </el-form>
    <template #footer>
      <div class="dialog-footer">
        <el-button type="primary" @click="insert">确定</el-button>
        <el-button type="danger" @click="dialogVisible = false">关闭</el-button>
      </div>
    </template>
  </el-dialog>
</template>

<script lang="ts" setup>
// 假设你有一个用于删除配置的 API 接口
// const deleteConfig = (id: string) => {
//   return axios.delete(`/api/systemconfig/${id}`);
// };

// 将 deleteConfig 添加到你的 API 导出中

import SystemconfigAPI, {
  NatureofPatientListDto,
  AdDSystemconfig,
} from "@/api/his/systemconfig/patientCategory/index";
const GetNatureofList = ref<NatureofPatientListDto[]>([]); //患者性质列表

onMounted(() => {
  loadData();
});
//加载数据
const loadData = () => {
  SystemconfigAPI.getForm().then((res: NatureofPatientListDto[]) => {
    GetNatureofList.value = res;
  });
};
//新增
const dialogVisible = ref(false);
//表单
const from = ref<AdDSystemconfig>({
  natureofPatientName: "",
  naturecode: "",
  typeinsurance: "",
  hospitallogo: "",
  status: "",
  natureTypeCard: "",
  medicaltype: "",
  remarks: "",
  concurrencyStamp: "",
  creationTime: "",
  creatorId: "",
  lastModificationTime: "",
  lastModifierId: "",
  isDeleted: false,
  deleterId: "",
  deletionTime: "",
});

//确定添加
const insert = () => {
  SystemconfigAPI.addConfing(from.value).then(() => {
    dialogVisible.value = false;
    loadData();
  });
};

// 删除
const deleteRow = (id: string) => {
  SystemconfigAPI.deleteConfig(id)
    .then(() => {
      // 删除成功后重新加载数据
      loadData();
    })
    .catch((error) => {
      console.error("删除失败:", error);
    });
};
</script>
