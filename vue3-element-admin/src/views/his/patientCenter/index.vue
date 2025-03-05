<template>
  <el-container>
    <el-main>
      <el-row :gutter="30">
        <el-col :span="5">
          <el-card style="border-color: aqua">
            <el-col :span="100" style="text-align: right">
              <el-button type="default" @click="switchPatient">患者切换</el-button>
            </el-col>
            <div>
              <h1>{{ patientCinfo?.patient_name }}</h1>
            </div>
            <div>
              <span class="label age">{{ patientCinfo?.patient_name }}</span>
              <span class="label gender">男</span>
              <span class="label status">自费</span>
              <span class="label transfer">转区中</span>
            </div>
            <div>科室：{{ patientCinfo?.patient_name }}</div>
            <div>病区：{{ patientCinfo?.patient_name }}</div>
            <div>床位：{{ patientCinfo?.patient_name }}</div>
            <div>入院时间：{{ patientCinfo?.patient_name }}</div>
            <div>住院天数：{{ patientCinfo?.patient_name }}</div>
            <div>住院次序：{{ patientCinfo?.patient_name }}</div>
            <div>入院诊断：{{ patientCinfo?.patient_name }}</div>
            <div>出院主诊断：{{ patientCinfo?.patient_name }}</div>
          </el-card>
        </el-col>
        <el-col :span="16">
          <el-card>
            <h3>费用账单</h3>
            <el-table style="width: 100%">
              <el-table-column prop="category" label="费用类别">11111</el-table-column>
              <el-table-column prop="amount" label="金额">22222</el-table-column>
            </el-table>
            <div style="text-align: right; margin-top: 20px">
              <h2>总金额：¥ 元</h2>
            </div>
          </el-card>
        </el-col>
      </el-row>
    </el-main>
  </el-container>
</template>
<script setup lang="ts">
import patientChenterApi, { patientChenterInfo, queryDto } from "@/api/his/patientCenter/index";
const formInline = ref<queryDto>({
  patientName: "",
});

var patientCinfo = ref<patientChenterInfo>();
var patientChenterlist = () => {
  patientChenterApi.GetpatientChenterInfo(formInline.value).then((res: any) => {
    patientCinfo.value = res;
  });
};
const switchPatient = () => {
  formInline.value.patientName = "彭雅彬";
  patientChenterlist();
};
onMounted(() => {
  patientChenterlist();
});
</script>
<style>
.label {
  display: inline-block;
  padding: 2px 5px;
  margin-right: 5px;
  border-radius: 3px;
  color: #333;
  font-size: 14px;
}

.age {
  background-color: #c0f0c0;
  /* 浅绿色 */
}

.gender {
  background-color: #f0e68c;
  /* 浅黄色 */
}

.status {
  background-color: #f5deb3;
  /* 米色 */
}

.transfer {
  background-color: #afeeee;
  /* 浅青色 */
}
</style>
