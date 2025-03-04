<template>
  <el-table :data="tableData" border style="width: 100%">
    <el-table-column prop="patient_name" label="患者姓名" />
    <el-table-column prop="admission_date" label="入院时间" />
    <el-table-column prop="discharge_date" label="出院时间" />
    <el-table-column prop="department_name" label="科室名称" />
    <el-table-column prop="doctor_name" label="主治医生姓名" />
    <el-table-column prop="room_type" label="病房类型" />  
    <el-table-column prop="admission_reason" label="入院信息" />
    <el-table-column prop="is_in_insurance" label="是否住院" />
  </el-table>
</template>

<script lang="ts" setup>
import InpatientRecordAPI, { inpatientRecordAPIQuery, InpatientRecordDto } from "@/api/his/inpatientRecord/index";

const tableData = ref<InpatientRecordDto[]>([]);

const formInline = reactive<inpatientRecordAPIQuery>({});

/** 页面加载完成后加载数据 */
onMounted(() => {
  InpatientRecordAPI.getList(formInline).then((res: InpatientRecordDto[]) => {
    tableData.value = res;
  });
});
</script>
