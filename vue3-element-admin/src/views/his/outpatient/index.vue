<template>
  <el-card class="houaner">
    <template #header>
      <div class="card-header">
        <span>门诊挂号</span>
      </div>
    </template>
    <el-form ref="ruleFormRef" :model="formInline" :rules="rules" label-width="110" status-icon>
      <el-row>
        <el-col :span="4">
          <el-form-item label="病例号/姓名:" prop="user" label-position="right">
            <el-input v-model="formInline.user" placeholder="最少1位字符" clearable />
          </el-form-item>
        </el-col>
        <el-col :span="2">
          <el-button size="small" type="primary" @click="">新建</el-button>
          <el-button size="small" type="primary" @click="">查询</el-button>
        </el-col>

        <el-col :span="3">
          <el-form-item size="small" style="width: 200px">
            <el-select placeholder="请选择">
              <el-option label="医保卡" value="医保卡" />
              <el-option label="电子凭证" value="电子凭证" />
              <el-option label="刷脸" value="刷脸" />
              <el-option label="身份证" value="身份证" />
            </el-select>
          </el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="姓名：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="性别：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="年龄：" label-position="right">{{}}</el-form-item>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="4">
          <el-form-item label="卡号：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="证件号：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="初复诊：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="医保余额：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="参保类别：" label-position="right">{{}}</el-form-item>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="4">
          <el-form-item label="*费用性质：" label-position="right">
            <el-input v-model="formInline.user" clearable />
          </el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="就诊原因：" prop="region">
            <el-select v-model="formInline.user" placeholder="请选择">
              <el-option label="Zone one" value="shanghai" />
              <el-option label="Zone two" value="beijing" />
            </el-select>
          </el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="手机号：" label-position="right">
            <el-input v-model="formInline.user" clearable />
          </el-form-item>
        </el-col>
        <el-col :span="2"></el-col>
        <el-col :span="5">
          <el-checkbox value="Offline activities" name="type">减免</el-checkbox>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="4">
          <el-form-item label="门诊类型：" prop="region">
            <el-select v-model="formInline.user" placeholder="请选择">
              <el-option label="Zone one" value="shanghai" />
              <el-option label="Zone two" value="beijing" />
            </el-select>
          </el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="科室：" label-position="right">
            <el-input v-model="formInline.user" clearable />
          </el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="挂号排班：" label-position="right">
            <el-input v-model="formInline.user" clearable />
          </el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="特病病种：" prop="region">
            <el-select v-model="formInline.user" placeholder="请选择">
              <el-option label="Zone one" value="shanghai" />
              <el-option label="Zone two" value="beijing" />
            </el-select>
          </el-form-item>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="4">
          <el-form-item label="挂号科室：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="医生：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="挂号费：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="诊疗费：" label-position="right">{{}}</el-form-item>
        </el-col>
        <el-col :span="5">
          <el-form-item label="总金额：" label-position="right">{{}}</el-form-item>
        </el-col>
      </el-row>
    </el-form>
  </el-card>
  <div class="flex-container">
    <el-button size="small" type="primary">F4:清空</el-button>
    <el-button size="small" type="primary" @click="">F8:确认挂号</el-button>
  </div>
  <el-card class="Kouamne">
    <template #header>
      <div class="card-header">
        <span>当日已挂号</span>
      </div>
    </template>
    <el-table :data="tableData" style="width: 100%; margin-top: -16px">
      <el-table-column type="index" width="50" />
      <el-table-column prop="name" label="科室" width="100" />
      <el-table-column prop="name" label="医生" width="100" />
      <el-table-column prop="name" label="病历号" width="100" />
      <el-table-column prop="name" label="门诊号" width="100" />
      <el-table-column prop="name" label="姓名" width="100" />
      <el-table-column prop="name" label="证件号" width="180" />
      <el-table-column prop="name" label="性别" width="100" />
      <el-table-column prop="name" label="挂号状态" width="100" />
      <el-table-column prop="name" label="就诊状态" width="100" />
      <el-table-column prop="name" label="费用性质" width="100" />
      <el-table-column prop="name" label="第一诊断" width="100" />
      <el-table-column prop="name" label="挂号日期" width="100" />
      <el-table-column prop="name" label="挂号操作时间" width="120" />
      <el-table-column prop="name" label="就诊序号" />
    </el-table>
  </el-card>
</template>

<script setup lang="ts">
import type { FormRules } from "element-plus";
const formInline = reactive({
  user: "",
  region: "",
  date: "",
});

interface RuleForm {
  user: "string";
}

const rules = reactive<FormRules<RuleForm>>({
  user: [{ required: true, message: "Please input Activity name", trigger: "blur" }],
});

const tableData = [
  {
    date: "2016-05-03",
    name: "Tom",
    address: "No. 189, Grove St, Los Angeles",
  },
  {
    date: "2016-05-02",
    name: "Tom",
    address: "No. 189, Grove St, Los Angeles",
  },
  {
    date: "2016-05-04",
    name: "Tom",
    address: "No. 189, Grove St, Los Angeles",
  },
  {
    date: "2016-05-01",
    name: "Tom",
    address: "No. 189, Grove St, Los Angeles",
  },
];
</script>

<style scoped>
.houaner {
  margin-top: 10px;
  width: 100%;
  height: 300px;
}
.card-header {
  font-size: 12px;
  margin-top: -12px;
  margin-bottom: -12px;
}
.Houer {
  size: small;
  margin-left: 10px;
}

.ponmr {
  font-size: 13px;
}
.mouler {
  margin-top: -5px;
}
.flex-container {
  display: flex;
  justify-content: flex-end; /* 整体靠右 */
  gap: 1px; /* 元素间距 */
  height: 100px;
}
.Kouamne {
  margin-top: -50px;
  width: 100%;
  height: 290px;
}

.demo-form-inline .el-input {
  --el-input-width: 220px;
}

.demo-form-inline .el-select {
  --el-select-width: 220px;
}
</style>
