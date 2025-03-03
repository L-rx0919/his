<template>
  <el-form :inline="true" :model="formInline" class="demo-form-inline">
    <el-form-item label="Approved by">
      <el-input v-model="formInline.name" placeholder="Approved by" clearable />
    </el-form-item>
    <el-form-item label="Approved by">
      <el-input v-model="formInline.phone" placeholder="Approved by" clearable />
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="onSubmit">Query</el-button>
    </el-form-item>
  </el-form>
  <el-table :data="tableData" style="width: 100%">
    <el-table-column prop="patient_name" label="Date" width="180" />
    <el-table-column prop="patient_gender" label="Name" width="180" />
    <el-table-column prop="patient_contact" label="Address" />
  </el-table>
</template>

<script lang="ts" setup>
import PatientAPI, { patientQuery, PatientDto } from "@/api/his/patient/index";

const tableData = ref<PatientDto[]>([]);

const formInline = reactive<patientQuery>({});

/**
 * 查询
 */
const onSubmit = () => {
  loadData();
};

/**
 * 加载数据
 */
const loadData = () => {
  PatientAPI.getList(formInline).then((res: PatientDto[]) => {
    tableData.value = res;
  });
};

/** 页面加载完成后加载数据 */
onMounted(() => {
  loadData();
});
</script>
