<template>
  <el-table :data="GetNatureofList" border style="width: 100%">
    <el-table-column prop="natureofPatientName" label="Date" width="180" />
    <el-table-column prop="naturecode" label="Name" width="180" />
    <el-table-column prop="typeinsurance" label="Name" width="180" />
    <el-table-column prop="hospitallogo" label="Name" width="180" />
    <el-table-column prop="status" label="Name" width="180" />
    <el-table-column prop="natureTypeCard" label="Name" width="180" />
    <el-table-column prop="medicaltype" label="Name" width="180" />
    <el-table-column prop="remarks" label="Name" width="180" />
    <el-table-column prop="creationTime" label="Name" width="180" />
  </el-table>
</template>

<script lang="ts" setup>
import SystemconfigAPI, { NatureofPatientListDto } from "@/api/his/systemconfig/index";
const GetNatureofList = ref<NatureofPatientListDto[]>([]);

onMounted(() => {
  loadData();
});

const loadData = () => {
  SystemconfigAPI.getForm().then((res: NatureofPatientListDto[]) => {
    GetNatureofList.value = res;
  });
};
</script>
