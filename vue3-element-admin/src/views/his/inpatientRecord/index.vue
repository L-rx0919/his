<template>
  <el-form-item>
      <el-button type="primary" @click="dialogVisible = true">新增住院</el-button>
    </el-form-item>

  <el-table :data="tableData" border style="width: 100%">
    <el-table-column prop="patient_name" label="患者姓名" />
    <el-table-column prop="admission_date" label="入院时间" >
       <template #default="{ row }">
        <span>{{ row.admission_date.slice(0, 10) }}</span>
      </template>
    </el-table-column>
    <el-table-column prop="discharge_date" label="出院时间" >
       <template #default="{ row }">
        <span>{{ row.discharge_date.slice(0, 10) }}</span>
      </template>
    </el-table-column>
    <el-table-column prop="department_name" label="科室名称" />
    <el-table-column prop="doctor_name" label="主治医生姓名" />
    <el-table-column prop="room_type" label="病房类型" />  
    <el-table-column prop="admission_reason" label="入院信息" />
    <el-table-column prop="is_in_insurance" label="是否住院" >
      <template #default="{ row }">
        <span v-if="row.card_status == '在院'">在院</span>
        <span v-else>离院</span>
      </template>
    </el-table-column>
    <el-table-column label="操作" >
      <template #default="{ row }">
        <el-button type="text" size="small" @click="delshow(row)">删除</el-button>
      </template>
      </el-table-column>
  </el-table>
  <el-dialog v-model="dialogVisible" title="新增住院" width="500" draggable overflow>
    <span>基本信息</span>
    <el-form :model="InpatientRecordInfor">
      <el-form-item label="患者姓名">
        <el-select v-model="InpatientRecordInfor.patient_id">
          <el-option v-for="item in InpatientRecordDto" :key="item.id" :label="item.patient_name" :value="item.id" />
        </el-select>
      </el-form-item>
      <el-form-item label="入院时间">
        <el-date-picker
          v-model="InpatientRecordInfor.admission_date"
          type="date"
          placeholder="Pick a date"
          style="width: 100%"
        />
      </el-form-item>
      <el-form-item label="出院时间">
        <el-date-picker
          v-model="InpatientRecordInfor.discharge_date"
          type="date"
          placeholder="Pick a date"
          style="width: 100%"
        />
      </el-form-item>
      <el-form-item label="科室名称">
        <el-select v-model="InpatientRecordInfor.department_id">
          <el-option v-for="item in InpatientRecordDto" :key="item.id" :label="item.department_name" :value="item.id" />
        </el-select>
      </el-form-item>
      <el-form-item label="主治医生姓名">
        <el-select v-model="InpatientRecordInfor.doctor_id">
          <el-option v-for="item in InpatientRecordDto" :key="item.id" :label="item.doctor_name" :value="item.id" />
        </el-select>
      </el-form-item>
      <el-form-item label="病房类型">
        <el-input v-model="InpatientRecordInfor.room_type" placeholder="请输入病房类型" clearable />
      </el-form-item>
      <el-form-item label="入院信息">
        <el-input type="textarea" v-model="InpatientRecordInfor.admission_reason" placeholder="请输入院信息" clearable />
      </el-form-item>
      <el-form-item label="是否住院">
        <el-radio-group v-model="InpatientRecordInfor.is_in_insurance">
        <el-radio value="在院">在院</el-radio>
        <el-radio value="离院">离院</el-radio>
      </el-radio-group>
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
import InpatientRecordAPI, { inpatientRecordAPIQuery, InpatientRecordDto,InpatientRecordInfor } from "@/api/his/inpatientRecord/index";


const tableData = ref<InpatientRecordDto[]>([]);

const formInline = reactive<inpatientRecordAPIQuery>({});

const loadlist = () => {
   InpatientRecordAPI.getList(formInline).then((res:InpatientRecordDto[]) => {
    tableData.value = res;
  });
}

/** 页面加载完成后加载数据 */
onMounted(() => {
 loadlist();
});
//删除弹出框
const delshow = (id: string) => {
  ElMessageBox.confirm(
    '确定要删除吗?',
    '警告',
    {
      confirmButtonText: 'OK',
      cancelButtonText: '取消',
      type: 'warning',
    }
  )
    .then(() => {
      InpatientRecordAPI.delList(id).then(() => {   
        debugger
        ElMessage({
          type: 'success',
          message: '删除成功!',
        })
        loadlist();
      })
    })
    .catch(() => {
      ElMessage({
        type: 'info',
        message: '已取消删除',
      })
    })
}

//对话框
const dialogVisible = ref(false);
const InpatientRecordInfor = ref<InpatientRecordInfor>({
  id: "",
  concurrencyStamp: "",
  creationTime: "",
  creatorId: "" ,
  lastModificationTime: "",
  lastModifierId: "",
  isDeleted: false,
  deleterId:"",
  deletionTime: "",
  patient_id: "",
  patient_name: "",
  admission_date: "",
  discharge_date: "",
  department_id: "",
  department_name: "",
  doctor_id: "",
  doctor_name: "",
  room_type: "",
  admission_reason: "",
  is_in_insurance: false
})
//添加住院信息
const insert = () => {
  InpatientRecordAPI.addList(InpatientRecordInfor.value).then(() => {
    dialogVisible.value = false;
    loadlist();
  });
};

</script>
