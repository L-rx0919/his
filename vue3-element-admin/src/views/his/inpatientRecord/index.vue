<template>
  <el-form-item>
    <el-button type="primary" @click="open(null)">新增住院</el-button>
  </el-form-item>

  <el-table :data="tableData" border style="width: 100%">
    <el-table-column width="55" type="selection" />
    <el-table-column prop="patient_name" label="患者姓名" />
    <el-table-column prop="admission_date" label="入院时间">
      <template #default="{ row }">
        <span>{{ row.admission_date.slice(0, 10) }}</span>
      </template>
    </el-table-column>
    <el-table-column prop="discharge_date" label="出院时间">
      <template #default="{ row }">
        <span>{{ row.discharge_date.slice(0, 10) }}</span>
      </template>
    </el-table-column>
    <el-table-column prop="department_name" label="科室名称" />
    <el-table-column prop="doctor_name" label="主治医生姓名" />
    <el-table-column prop="room_type" label="病房类型" />
    <el-table-column prop="admission_reason" label="入院信息" />
    <el-table-column prop="is_in_insurance" label="是否住院">
      <template #default="{ row }">
          <span>{{ row.is_in_insurance ? '住院' : '离院' }}</span>
      </template>
    </el-table-column>
    <el-table-column label="操作">
      <template #default="{ row }">
        <el-button type="text" size="small" @click="delshow(row)">删除</el-button>
        <el-button type="text" size="small" @click="open(row)">查看</el-button>
      </template>
    </el-table-column>
  </el-table>
  <el-dialog v-model="logic.dialogVisible" :title="logic.title" width="500" draggable overflow>
    <el-form :model="inserttInpatientRecordInfor">
      <el-form-item label="患者姓名">
        <el-select v-model="inserttInpatientRecordInfor.patient_id">
          <el-option
            v-for="item in patientlist"
            :key="item.id"
            :label="item.patient_name"
            :value="item.id"
          />
        </el-select>
      </el-form-item>
      <el-form-item label="入院时间">
        <el-date-picker
          v-model="inserttInpatientRecordInfor.admission_date"
          type="date"
          style="width: 100%"
        />
      </el-form-item>
      <el-form-item label="出院时间">
        <el-date-picker
          v-model="inserttInpatientRecordInfor.discharge_date"
          type="date"
          style="width: 100%"
        />
      </el-form-item>
      <el-form-item label="科室名称">
        <el-select v-model="inserttInpatientRecordInfor.department_id">
          <el-option
            v-for="item in deptlist"
            :key="item.id"
            :label="item.name"
            :value="item.id"
          />
        </el-select>
      </el-form-item>
      <el-form-item label="主治医生姓名">
        <el-select v-model="inserttInpatientRecordInfor.doctor_id">
          <el-option
            v-for="item in doctorlist"
            :key="item.id"
            :label="item.name"
            :value="item.id"
          />
        </el-select>
      </el-form-item>
      <el-form-item label="病房类型">
        <el-input v-model="inserttInpatientRecordInfor.room_type" placeholder="请输入病房类型" clearable />
      </el-form-item>
      <el-form-item label="入院信息">
        <el-input
          v-model="inserttInpatientRecordInfor.admission_reason"
          type="textarea"
          placeholder="请输入院信息"
          clearable
        />
      </el-form-item>
      <el-form-item label="是否住院">
        <el-radio-group v-model="inserttInpatientRecordInfor.is_in_insurance">
            <el-radio :value="true">住院</el-radio>
            <el-radio :value="false">离院</el-radio>
        </el-radio-group>
      </el-form-item>
    </el-form>
    <template #footer>
      <div class="dialog-footer">
        <el-button type="primary" @click="insert()">确定</el-button>
        <el-button type="danger" @click="logic.dialogVisible = false">关闭</el-button>
      </div>
    </template>
  </el-dialog>
</template>

<script lang="ts" setup>
import inpatientRecordAPI, {
  type InpatientRecordDto,
  type inpatientRecordAPIQuery,
  type InpatientRecordInfor,
  type GetPatientDto,
  type GetDoctorDto,
  type GetDepartmentDto
} from "@/api/his/inpatientRecord/index";
import { ref, onMounted } from "vue";
import { ElMessage, ElMessageBox } from "element-plus";
const loadlist = () => {
  inpatientRecordAPI.getList(formInline.value).then((res) => {
    tableData.value = res;
  });
};

//删除弹出框
const delshow = (id: string) => {
  ElMessageBox.confirm("确定要删除吗?", "警告", {
    confirmButtonText: "OK",
    cancelButtonText: "取消",
    type: "warning",
  })
    .then(() => {
      inpatientRecordAPI.delList(id).then(() => {
        ElMessage({
          type: "success",
          message: "删除成功!",
        });
        loadlist();
      });
    })
    .catch(() => {
      ElMessage({
        type: "info",
        message: "已取消删除",
      });
    });
};
//对话框
//const dialogVisible = ref(false);
const deptlist = ref<GetDepartmentDto[]>([]);
const doctorlist = ref<GetDoctorDto[]>([]);
const patientlist = ref<GetPatientDto[]>([]);

//下拉列表
const GetSel = () => {
  inpatientRecordAPI.GetDepartment().then((res: GetDepartmentDto[]) => {
    deptlist.value = res;
  });
  inpatientRecordAPI.GetDoctor().then((res: GetDoctorDto[]) => {
    doctorlist.value = res;
  });
  inpatientRecordAPI.GetPatient().then((res: GetPatientDto[]) => {
    patientlist.value = res;
  });
};

const inserttInpatientRecordInfor = ref<InpatientRecordInfor>({
  patient_id: "",
  admission_date: "",
  discharge_date: "",
  department_id: "",
  doctor_id: "",
  room_type: "",
  admission_reason: "",
  is_in_insurance: true,
});

//逻辑对象
const logic = reactive({
  dialogVisible: false,
  title: ""
})

//添加住院信息
const insert = () => {
  inpatientRecordAPI.addInpatientRecord(inserttInpatientRecordInfor.value).then(() => {
    logic.dialogVisible = false;
    loadlist();
  });
};

// 修改
const saveInpatientRecord = ref<InpatientRecordDto>({
  id: "",
  concurrencyStamp: "",
  creationTime: "",
  creatorId: "",
  lastModificationTime: "",
  lastModifierId:"",
  isDeleted: false,
  deleterId: "",
  deletionTime: "",
  patient_id: "",
  patient_name: "",
  admission_date: "",
  discharge_date: "",
  department_id: "",
  department_name: "",
  doctor_id: "",
  doctor_name:"",
  room_type: "",
  admission_reason: "",
  is_in_insurance: true,
});
const open = (row:any) => {
  logic.dialogVisible = true
  if (row == null) {
    logic.title = "新增住院信息"
    inserttInpatientRecordInfor.value = ({
  patient_id: "",
  admission_date: "",
  discharge_date: "",
  department_id: "",
  doctor_id: "",
  room_type: "",
  admission_reason: "",
  is_in_insurance: true,
  })
  }
  else {
    saveInpatientRecord.value = ({
    id: row.id,
  concurrencyStamp: row.concurrencyStamp,
  creationTime: row.creationTime,
  creatorId: row.creatorId,
  lastModificationTime: row.lastModificationTime,
  lastModifierId:row.lastModifierId,
  isDeleted: row.isDeleted,
  deleterId: row.deleterId,
  deletionTime: row.deletionTime,
  patient_id: row.patient_id,
  patient_name: row.patient_name,
  admission_date: row.admission_date,
  discharge_date: row.discharge_date,
  department_id: row.department_id,
  department_name: row.department_name,
  doctor_id: row.doctor_id,
  doctor_name:row.doctor_name,
  room_type: row.room_type,
  admission_reason: row.admission_reason,
  is_in_insurance: row.is_in_insurance,
  }),
  logic.dialogVisible = true,
  logic.title="查看住院信息"
  }
  
}


const tableData = ref<InpatientRecordDto[]>([]);
const formInline = ref<inpatientRecordAPIQuery>({});



/** 页面加载完成后加载数据 */
onMounted(() => {
  loadlist();
  GetSel();
});
</script>
