<template>
  <el-card class="houaner">
    <template #header>
      <div class="card-header">
        <span>门诊挂号</span>
      </div>
    </template>
    <div class="card-foot">
      <el-form label-width="auto" style="max-width: 600px">
        <el-form-item label="病例号/姓名" size="small">
          <el-input style="width: 150px" size="small" />
          <el-button type="primary" class="Houer" @click="">新建</el-button>
          <el-button size="small">查询</el-button>
          <el-form-item label="" style="width: 100px">
            <el-select placeholder="请选择">
              <el-option label="医保卡" value="医保卡" />
              <el-option label="电子凭证" value="电子凭证" />
              <el-option label="刷脸" value="刷脸" />
              <el-option label="身份证" value="身份证" />
            </el-select>
          </el-form-item>
          <span>姓名:{{}}</span>
          <span></span>
          <span></span>
        </el-form-item>
      </el-form>
    </div>
  </el-card>
</template>

<script setup lang="ts"></script>

<style scoped>
.houaner {
  margin-top: 10px;
  margin-left: 10px;
}
.card-header {
  font-size: 12px;
  margin-top: -12px;
  margin-bottom: -12px;
}
.card-foot {
  margin-top: -12px;
}
.Houer {
  size: small;
  margin-left: 10px;
}
</style>
