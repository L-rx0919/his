<template>
  <el-form-item>
    <el-button type="primary" @click="">新增住院</el-button>
  </el-form-item>

  <el-table :data="tableData" border style="width: 100%">
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
        <span v-if="row.card_status === '在院'">在院</span>
        <span v-else>离院</span>
      </template>
    </el-table-column>
    <el-table-column label="操作">
      <template #default="{ row }">
        <el-button type="text" size="small" @click="delshow(row.id)">删除</el-button>
      </template>
    </el-table-column>
  </el-table>
</template>

<script lang="ts" setup>
import InpatientRecordAPI, {
  inpatientRecordAPIQuery,
  InpatientRecordDto,
} from "@/api/his/inpatientRecord/index";

const tableData = ref<InpatientRecordDto[]>([]);

const formInline = reactive<inpatientRecordAPIQuery>({});

const loadlist = () => {
  InpatientRecordAPI.getList(formInline).then((res: InpatientRecordDto[]) => {
    tableData.value = res;
  });
};

/** 页面加载完成后加载数据 */
onMounted(() => {
  loadlist();
});

//删除弹出框
const delshow = (id: string) => {
  ElMessageBox.confirm("确定要删除吗?", "警告", {
    confirmButtonText: "OK",
    cancelButtonText: "取消",
    type: "warning",
  })
    .then(() => {
      InpatientRecordAPI.delList(id)
        .then(() => {
          ElMessage({
            type: "success",
            message: "删除成功!",
          });
          loadlist();
        })
        .catch((_error) => {
          // 如果删除失败，显示失败消息
          ElMessage({
            type: "error",
            message: "删除失败，请稍后再试。",
          });
        });
    })
    .catch(() => {
      ElMessage({
        type: "info",
        message: "已取消删除",
      });
    });
};
</script>
