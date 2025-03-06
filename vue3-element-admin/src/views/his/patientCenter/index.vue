<template>
  <el-container>
    <el-main>
      <el-row :gutter="30">
        <el-col :span="5">
          <el-card style="border-color: aqua">
            <el-col :span="100" style="text-align: right">
              <el-button type="default" @click="dialogVisible = true">患者切换</el-button>
            </el-col>
            <div v-for="item in patientCinfo">
              <h1>{{ item.patient_name }}</h1>
            </div>
            <div v-for="item in patientCinfo">
              <span class="label age">{{ item.patient_age }}</span>
              <span class="label gender">{{ item.patient_gender }}</span>
              <span class="label status">自费</span>
              <span class="label transfer">转区中</span>
              <div>科室：{{ item.key_department_name }}</div>
              <div>病区：{{ item.department_type }}</div>
              <div>床位:0001</div>
              <div>入院时间:2025-3-6 14:17</div>
              <div>出院时间：</div>
              <div>住院天数5</div>
              <div>住院次序：第一次住院</div>
              <div>入院诊断：有病</div>
              <div>出院主诊断：</div>
              <div>过敏史：</div>
              <div>住院医生：</div>
              <div>主治医生：{{ item.name }}</div>
              <div>主任医生：</div>
            </div>
          </el-card>
        </el-col>
        <el-col :span="16">
          <el-card>
            <h3>费用账单</h3>

            <el-table :data="listdto" style="width: 100%">
              <el-table-column prop="templateName" label="费用类别" />
              <el-table-column prop="templateName" label="金额" />
            </el-table>
            <div style="text-align: right; margin-top: 20px">
              <h2>总金额：¥ 888 元</h2>
            </div>
          </el-card>
        </el-col>
      </el-row>
    </el-main>
  </el-container>
  <!--患者-->
  <el-dialog v-model="dialogVisible" title="住院患者查询" width="500">
    <el-form :inline="true" :model="formInline" class="demo-form-inline">
      <el-form-item label="患者名称">
        <el-input v-model="formInline.patientName" placeholder="请输入名称" clearable />
      </el-form-item>
      <el-form-item>
        <el-button type="primary" style="margin-left: 30px" @click="patientChenterlist()">
          查询
        </el-button>
      </el-form-item>
    </el-form>
    <el-table :data="patientCinfo" style="width: 100%">
      <el-table-column prop="patient_name" label="名称" />
      <el-table-column prop="patient_gender" label="性别" />
      <el-table-column prop="key_department_name" label="医生" />
    </el-table>
    <template #footer>
      <div class="dialog-footer">
        <el-button @click="dialogVisible = false">取消</el-button>
        <el-button type="primary" @click="dialogVisible = false">确定</el-button>
      </div>
    </template>
  </el-dialog>
</template>
<script setup lang="ts">
import patientChenterApi, {
  patientChenterInfo,
  queryDto,
  queryId,
  queryList,
} from "@/api/his/patientCenter/index";

//切换患者
const dialogVisible = ref(false);
//条件
const formInline = ref<queryDto>({
  patientName: "彭雅彬",
});

//加载
var patientCinfo = ref<patientChenterInfo[]>([]);
var patientChenterlist = () => {
  patientChenterApi.GetpatientChenterInfo(formInline.value).then((res: any) => {
    patientCinfo.value = res;
    // 取第一个患者的 department_id 赋值给 id.value
    if (res.length > 0) {
      id.value.id = res[0].department_id;
      getlistdto(); // 获取列表数据
    }
  });
};

var id = ref<queryId>({
  id: "",
});
var listdto = ref<queryList[]>([]);

const getlistdto = () => {
  patientChenterApi.GetChargingModule(id.value).then((res: queryList[]) => {
    listdto.value = res;
  });
};
//钩子
onMounted(() => {
  patientChenterlist();
  getlistdto();
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
