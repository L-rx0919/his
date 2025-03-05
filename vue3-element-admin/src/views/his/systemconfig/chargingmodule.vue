<template>
  <el-table :data="GetList" style="width: 100%">
    <el-table-column prop="date" label="Date" width="180" />
    <el-table-column prop="name" label="Name" width="180" />
    <el-table-column prop="address" label="Address" />
  </el-table>
</template>

<script lang="ts" setup>
import SystemconfigAPI, { ChargingListDto } from "@/api/his/systemconfig/Chargingmodule";

const GetList = ref<ChargingListDto[]>([]);
</script>
