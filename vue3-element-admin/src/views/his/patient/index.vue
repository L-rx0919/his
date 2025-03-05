<template>
  <el-form :inline="true" :model="formInline" class="demo-form-inline">
    <el-form-item label="患者名称">
      <el-input v-model="formInline.name" placeholder="请输入名称" clearable />
    </el-form-item>
    <el-form-item label="患者手机号">
      <el-input v-model="formInline.phone" placeholder="请输入手机号" clearable />
    </el-form-item>
    <el-form-item>
      <el-button type="primary" style="margin-left: 30px" @click="onSubmit">查询</el-button>
      <el-button type="primary" style="margin-left: 200px" @click="dialogVisible = true">
        一卡通办理
      </el-button>
      <el-button type="primary" style="margin-left: 10px">一卡通启用</el-button>
      <el-button type="primary" style="margin-left: 10px">一卡通停用</el-button>
    </el-form-item>
  </el-form>
  <el-table :data="tableData" style="width: 100%">
    <el-table-column prop="patient_name" label="姓名" width="180" />
    <el-table-column prop="patient_gender" label="性别" />
    <el-table-column prop="patient_age" label="年龄" />
    <el-table-column prop="marital_status" label="婚姻状态" />
    <el-table-column prop="emergency_contact" label="紧急联系人" />
    <el-table-column prop="patient_address" label="住址" />
    <el-table-column prop="card_status" label="卡状态">
      <template #default="{ row }">
        <span v-if="row.card_status === '启用'">启用</span>
        <span v-else>停用</span>
      </template>
    </el-table-column>
    <el-table-column prop="creationTime" label="创建时间">
      <template #default="{ row }">
        <span>{{ row.creationTime.slice(0, 10) }}</span>
      </template>
    </el-table-column>
  </el-table>
  <el-dialog v-model="dialogVisible" title="一卡通办理" width="500" draggable overflow>
    <span>基本信息</span>
    <el-form :model="patientCardInfo">
      <el-form-item label="姓名">
        <el-select v-model="patientCardInfo.patient_id">
          <el-option v-for="item in PatientNameAndIdDto" :key="item.id" :label="item.patient_name" :value="item.id" />
        </el-select>
      </el-form-item>
      <el-form-item label="联系电话">
        <el-input v-model="patientCardInfo.contact_phone" placeholder="请输入联系电话" clearable />
      </el-form-item>
      <el-form-item label="卡状态">
        <el-select v-model="patientCardInfo.card_status">
          <el-option label="启用" value="启用"></el-option>
          <el-option label="停用" value="停用"></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="卡类型">
        <el-select v-model="patientCardInfo.card_type">
          <el-option label="普通卡" value="普通卡"></el-option>
          <el-option label="白金卡" value="白金卡"></el-option>
          <el-option label="钻石卡" value="钻石卡"></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="余额">
        <el-input v-model="patientCardInfo.balance" placeholder="请输入余额" clearable />
      </el-form-item>
      <el-form-item label="所属科室">
        <el-select v-model="patientCardInfo.associated_dept">
          <el-option v-for="item in deptlist" :key="item.id" :label="item.name" :value="item.id" />
        </el-select>
      </el-form-item>
    </el-form>
    <template #footer>
      <div class="dialog-footer">
        <el-button type="primary" @click="insert">确定</el-button>
        <el-button type="danger" @click="dialogVisible = false">关闭</el-button>
      </div>
    </template>
  </el-dialog>
</template>
<script lang="ts" setup>
import PatientAPI, {
  patientQuery,
  PatientCardInfo,
  GetPatientNameAndIdDto,
  GetDepartmentDto,
  PatientCardInfoList,
} from "@/api/his/patient/index";

const tableData = ref<PatientCardInfoList[]>([]);

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
  PatientAPI.getPatientCardInfos().then((res: any) => {
    tableData.value = res;
  });
};
const deptlist = ref<GetDepartmentDto[]>([]);
const GetDepartment = () => {
  PatientAPI.GetDepartment().then((res: GetDepartmentDto[]) => {
    deptlist.value = res;
  });
  PatientAPI.GetPatientNameAndId().then((res: GetPatientNameAndIdDto[]) => {
    PatientNameAndIdDto.value = res;
  });
};
//一卡通办理
const dialogVisible = ref(false);
const PatientNameAndIdDto = ref<GetPatientNameAndIdDto[]>([]);
if (!dialogVisible.value) {
  GetDepartment();
}
const patientCardInfo = ref<PatientCardInfo>({
  concurrencyStamp: "",
  creationTime: "",
  creatorId: "",
  lastModificationTime: "",
  lastModifierId: "",
  isDeleted: false,
  deleterId: "",
  deletionTime: "",
  patient_id: "",
  card_status: "",
  card_type: "",
  balance: 0,
  create_date: "",
  expiry_date: "",
  last_transaction_date: "",
  card_owner_name: "",
  associated_dept: "",
  contact_phone: "",
  remarks: "",
});
const insert = () => {
  PatientAPI.insertPatientCardInfo(patientCardInfo.value).then(() => {
    dialogVisible.value = false;
    loadData();
  });
};
/** 页面加载完成后加载数据 */
onMounted(() => {
  loadData();
});
</script>
