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
              <h1>张三</h1>
            </div>
            <div>
              <span class="label age">31岁</span>
              <span class="label gender">男</span>
              <span class="label status">自费</span>
              <span class="label transfer">转区中</span>
            </div>
            <div>科室：</div>
            <div>病区：</div>
            <div>床位：</div>
            <div>入院时间：</div>
            <div>住院天数：</div>
            <div>住院次序：</div>
            <div>入院诊断：</div>
            <div>出院主诊断：</div>
          </el-card>
        </el-col>
        <el-col :span="16">
          <el-card>
            <h3>费用账单</h3>
            <el-table style="width: 100%">
              <el-table-column prop="category" label="费用类别"></el-table-column>
              <el-table-column prop="amount" label="金额"></el-table-column>
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
