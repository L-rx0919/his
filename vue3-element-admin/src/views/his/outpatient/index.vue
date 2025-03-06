<template>
  <div>
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
            <el-button size="small" type="primary" @click="Kousne">新建</el-button>
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
  </div>
  <div>
    <el-dialog v-model="dialogFormVisible" title="一卡通办理" width="1100">
      <el-scrollbar height="300px">
        <el-form ref="ruleFormRef" :model="formInline" :rules="rules" label-width="110" status-icon>
          <el-row>
            <el-col :span="24">基本信息</el-col>
          </el-row>
          <hr class="custom-line" />
          <el-row>
            <el-col :span="5">
              <el-form-item label="卡号：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>
            <el-col :span="5">
              <el-form-item label="病历号：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              <el-form-item label="患者姓名：">
                <el-input v-model="formInline.user" clearable style="width: 100px" />
                <el-input v-model="formInline.user" clearable style="width: 80px" />
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="性别：">
                <el-radio-group v-model="formInline.user">
                  <el-radio value="Sponsor">男</el-radio>
                  <el-radio value="Venue">女</el-radio>
                </el-radio-group>
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="证件类型：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="证件号：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              <el-form-item label="出生年月：">
                <el-date-picker
                  v-model="formInline.date"
                  type="date"
                  clearable
                  style="width: 180px"
                />
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="年龄：">
                <el-input v-model="formInline.user" clearable style="width: 40px" />
                <el-select v-model="formInline.region" clearable style="width: 60px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="国籍：">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="民族：">
                <el-select v-model="formInline.region" clearable style="width: 120px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              <el-form-item label="籍贯：">
                <el-input v-model="formInline.user" clearable style="width: 180px" />
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="职业：">
                <el-select v-model="formInline.region" clearable style="width: 120px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="最佳联系方式：">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="微信：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              <el-form-item label="邮箱：">
                <el-input v-model="formInline.user" clearable style="width: 180px" />
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="手机：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="电话：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="患者来源：">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              <el-form-item label="婚否：">
                <el-select v-model="formInline.region" clearable style="width: 180px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="学历：">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="现地址：">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              省(区,市)
              <el-form-item style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              市
              <el-form-item style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 180px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              县
              <el-form-item label="地址：" style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="出生址：">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              省(区,市)
              <el-form-item style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              市
              <el-form-item style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 180px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              县
              <el-form-item label="地址：" style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>
            <el-col :span="1">
              <el-button type="primary">同上</el-button>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="户口地址：">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              省(区,市)
              <el-form-item style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              市
              <el-form-item style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 180px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              县
              <el-form-item label="地址：" style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>
            <el-col :span="1">
              <el-button type="primary">同上</el-button>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="紧急联系人关系">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="紧急联络人：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              <el-form-item label="紧急联络电话：">
                <el-input v-model="formInline.user" clearable style="width: 180px" />
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="联系人地址：">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              省(区,市)
              <el-form-item style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              市
              <el-form-item style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 180px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>

            <el-col :span="5">
              县
              <el-form-item label="地址：" style="margin-top: -20px">
                <el-select v-model="formInline.region" clearable style="width: 105px">
                  <el-option label="岁" value="shanghai" />
                  <el-option label="月" value="beijing" />
                  <el-option label="天" value="shanghai" />
                  <el-option label="小时" value="beijing" />
                </el-select>
              </el-form-item>
            </el-col>
            <el-col :span="1">
              <el-button type="primary">同上</el-button>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="单位：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="单位地址：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              <el-form-item label="单位电话：">
                <el-input v-model="formInline.user" clearable style="width: 180px" />
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="出生地邮编：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="现住地邮编：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              <el-form-item label="户口地邮编：">
                <el-input v-model="formInline.user" clearable style="width: 180px" />
              </el-form-item>
            </el-col>
            <el-col :span="5">
              <el-form-item label="单位邮编：">
                <el-input v-model="formInline.user" clearable style="width: 105px" />
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="5">
              <el-form-item label="过敏史：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="5">
              <el-form-item label="疾病史：">
                <el-input v-model="formInline.user" clearable style="width: 120px" />
              </el-form-item>
            </el-col>

            <el-col :span="6.5">
              <el-form-item label="备注：">
                <el-input v-model="formInline.user" clearable style="width: 180px" />
              </el-form-item>
            </el-col>
          </el-row>
        </el-form>
      </el-scrollbar>
      <template #footer>
        <div class="dialog-footer">
          <el-button @click="dialogFormVisible = false">确认</el-button>
          <el-button type="primary" @click="dialogFormVisible = false">关闭</el-button>
        </div>
      </template>
    </el-dialog>
  </div>
</template>

<script setup lang="ts">
import type { FormRules } from "element-plus";
//#region 确认挂号
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
//#endregion

//#region 添加患者基本信息
const dialogFormVisible = ref(false);

const Kousne = () => {
  dialogFormVisible.value = true;
};
//#endregion

//#region 当日已挂号
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
//#endregion
</script>

<style scoped>
.custom-line {
  border: 1px solid #888a8b; /* 颜色和粗细 */
  margin: 5px 0; /* 上下边距 */
}
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
