<template>
  <div class="sms-container">
    <el-card class="box-card">
      <template #header>
        <div class="card-header">
          <span class="font-bold">发送短信</span>
        </div>
      </template>

      <el-form ref="smsFormRef" label-width="100px" @submit.prevent>
        <el-form-item label="手机号码" prop="phoneNumber">
          <el-input v-model="smsForm.phoneNumber" placeholder="请输入手机号码" />
        </el-form-item>

        <el-form-item>
          <el-button type="primary" @click="sendSms">发送 SMS</el-button>
        </el-form-item>
      </el-form>
    </el-card>
  </div>
</template>

<script setup lang="ts">
import SMSAPI, { dto } from "@/api/his/sms/sms";

const smsForm = ref<dto>({
  phoneNumber: "",
});

const sendSms = () => {
  SMSAPI.sendSms(smsForm.value).then((res) => {
    console.log(res);
  });
};
onMounted(() => {
  sendSms();
});
</script>

<style scoped>
.sms-container {
  padding: 20px;
}

.card-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
</style>
