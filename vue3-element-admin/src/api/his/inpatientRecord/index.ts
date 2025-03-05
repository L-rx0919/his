import request from "@/utils/request";

/* 基础API URL*/
const InpatientRecord_BASE_URL = "/api/v1/his/inpatientRecord";
const InpatientRecordAPI = {
  /**
   * 获取患者列表
   *
   * @param queryParams 查询参数
   * @returns 字典分页结果
   */
  */
  //添加住院信息
  addList(data: InpatientRecordInfor) {
    return request({
      url: `${inpatientRecord_BASE_URL}/insertInpatientRecordinfo`,
      method: "post",
      params: data,
    });
  },
  //获取科室
  //  GetDepartment() {
  //   return request<any, GetDepartmentDto[]>({
  //     url: `${inpatientRecord_BASE_URL}/getDepartment`,
  //     method: "get",
  //     params: {},
  //   });
  // },
  //获取住院信息
  getList(queryParams: inpatientRecordAPIQuery) {
    return request<any, InpatientRecordDto[]>({
      url: `${InpatientRecord_BASE_URL}/patient_id`,
      method: "get",
      params: queryParams,
    });
  },
  addList(data: InpatientRecordInfor) {
    return request({
      url: `${InpatientRecord_BASE_URL}/insertPatientCardInfo`,
      method: "post",
      data: data, // 传递 PatientCardInfo 对象
    });
  },
  //删除住院信息
  delList(id: string) {
    return request({
      url: `${InpatientRecord_BASE_URL}/id`,
      method: "delete",
      params: id,
    });
  },

};

export default InpatientRecordAPI;

export interface inpatientRecordAPIQuery {
  patient_id?: string | undefined;
}

export interface InpatientRecordInfor {
  id: string;
  concurrencyStamp: string;
  creationTime: string;
  creatorId: string | null;
  lastModificationTime: string | null;
  lastModifierId: string | null;
  isDeleted: boolean;
  deleterId: string | null;
  deletionTime: string | null;
  patient_id: string;
  patient_name: string;
  admission_date: string;
  discharge_date: string;
  department_id: string;
  department_name: string;
  doctor_id: string;
  doctor_name: string;
  room_type: string;
  admission_reason: string;
  is_in_insurance: boolean;
}

export interface InpatientRecordDto {
  id: string;
  concurrencyStamp: string;
  creationTime: string;
  creatorId: string | null;
  lastModificationTime: string | null;
  lastModifierId: string | null;
  isDeleted: boolean;
  deleterId: string | null;
  deletionTime: string | null;
  patient_id: string;
  patient_name: string;
  admission_date: string;
  discharge_date: string;
  department_id: number;
  department_name: string;
  doctor_id: number;
  doctor_name: string;
  room_type: string;
  admission_reason: string;
  is_in_insurance: boolean;
}
