<template>
  <el-button type="danger" @click="dialogVisible = true">新增收费模板</el-button>
  <el-button type="primary" @click="loadData">修改</el-button>

  <el-button type="primary" @click="loadData">搜索</el-button>
  <el-table :data="GetList" style="width: 100%">
    <el-table-column prop="departmentID" label="Name" width="180" />
    <el-table-column prop="templateName" label="Name" width="180" />
    <el-table-column prop="departmentName" label="Address" width="180" />
    <el-table-column prop="department_type" label="Address" width="180" />
    <el-table-column prop="name" label="Address" width="180" />
    <el-table-column prop="location" label="Address" width="180" />
    <el-table-column prop="phone" label="Address" width="180" />
    <el-table-column prop="numberCutions" label="Address" width="180" />
    <el-table-column prop="typeRehabil" label="Address" width="180" />
    <el-table-column prop="parts" label="Address" width="180" />
    <el-table-column prop="singltreatment" label="Address" width="180" />
    <el-table-column prop="unittime" label="Address" width="180">
      <template #default="{ row }">
        <span>{{ row.unittime.slice(0, 10) }}</span>
      </template>
    </el-table-column>
  </el-table>

  <el-dialog v-model="dialogVisible" title="新增收费模板" width="500" draggable overflow>
    <span>基本信息</span>
    <el-form :model="from">
      <el-form-item label="权限科室	">
        <el-select v-model="from.departmentID">
          <el-option label="恶妇塞缝" value="1"></el-option>
          <el-option label="妇科" value="2"></el-option>
          <el-option label="儿科" value="3"></el-option>
          <el-option label="泌尿科" value="4"></el-option>
          <el-option label="内科" value="5"></el-option>
          <el-option label="外科" value="6"></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="模板名称">
        <el-input v-model="from.departmentName" placeholder="请输入模板名称" clearable />
      </el-form-item>

      <el-form-item label="单次治疗量">
        <el-input v-model="from.singltreatment" placeholder="请输入单次治疗量" clearable />
      </el-form-item>
      <el-form-item label="执行次数">
        <el-input v-model="from.numberCutions" placeholder="请输入执行次数" clearable />
      </el-form-item>

      <el-form-item label="康复类别">
        <el-select v-model="from.typeRehabil">
          <el-option label="手术" value="1"></el-option>
          <el-option label="放疗" value="2"></el-option>
          <el-option label="手术+放疗" value="3"></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="部位">
        <el-input v-model="from.parts" placeholder="请输入执行次数" clearable />
      </el-form-item>

      <el-form-item label="单位时长">
        <el-input v-model="from.unittime" type="date" placeholder="请输入单位时长" clearable />
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
import chargingmoduleAPI, {
  ChargingListDto,
  addChargingModules,
} from "@/api/his/systemconfig/chargingmodule/index";
onMounted(() => {
  loadData();
});

//弹窗
const dialogVisible = ref(false);
const GetList = ref<ChargingListDto[]>([]);
//表单
const from = ref<addChargingModules>({});

const loadData = async () => {
  chargingmoduleAPI.getForm().then((res: ChargingListDto[]) => {
    GetList.value = res;
  });
};

//确定添加
const insert = () => {
  chargingmoduleAPI.addChargingModule(from.value).then(() => {
    dialogVisible.value = false;
    loadData();
  });
};
</script>
