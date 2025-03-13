import request from "@/utils/request";

/* 基础API URL*/
const inpatientRecord_BASE_URL = "/api/v1/his/inpatientRecord";
const inpatientRecordAPI = {
  /**
   * 获取患者列表
   *
   * @param inpatientRecordInfor 查询参数
   * @returns 字典分页结果
   */
  //添加住院信息
  addInpatientRecord(data: InpatientRecordInfor) {
    return request({
      url: `${inpatientRecord_BASE_URL}/insertInpatientRecord`,
      method: "post",
      data: data,
    });
  },
  //获取科室
  GetDepartment() {
    return request<any, GetDepartmentDto[]>({
      url: `${inpatientRecord_BASE_URL}/getDepartment`,
      method: "get",
      params: {},
    });
  },
  /**
   * 获取患者列表
   *
   * @param queryParams 查询参数
   * @returns 字典分页结果
   */
  //获取患者
  GetPatient() {
    return request<any, GetPatientDto[]>({
      url: `${inpatientRecord_BASE_URL}/getPatient`,
      method: "get",
      params: {},
    });
  },
  //获取医生
  GetDoctor() {
    return request<any, GetDoctorDto[]>({
      url: `${inpatientRecord_BASE_URL}/getDoctor`,
      method: "get",
      params: {},
    });
  },
  //获取住院信息
  getList(queryParams: inpatientRecordAPIQuery) {
    return request<any, PageResult<InpatientRecordDto[]>>({
      url: `${inpatientRecord_BASE_URL}/patient_id`,
      method: "get",
      params: queryParams,
    });
  },
  //删除住院信息
  delList(id: string) {
    return request({
      url: `${inpatientRecord_BASE_URL}/id`,
      method: "delete",
      params: id,
    });
  },
  //修改住院信息
  updInpatientRecord(data: InpatientRecordDto) {
    return request({
      url: `${inpatientRecord_BASE_URL}/updInpatientRecord`,
      method: "put",
      data: data,
    });
  },
};
export default inpatientRecordAPI;
export interface inpatientRecordAPIQuery extends PageQuery {
  patient_id?: string | undefined;
}
//科室
export interface GetDepartmentDto {
  id: string; // 科室ID
  name: string; // 科室名称
}
//患者
export interface GetPatientDto {
  id: string; // 患者ID
  patient_name: string; // 患者名称
}
//医生
export interface GetDoctorDto {
  id: string; // 医生ID
  name: string; // 医生名称
}
export interface InpatientRecordInfor {
  patient_id: string;
  admission_date: string;
  discharge_date: string;
  department_id: string;
  doctor_id: string;
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
  department_id: string;
  department_name: string;
  doctor_id: string;
  doctor_name: string;
  room_type: string;
  admission_reason: string;
  is_in_insurance: boolean;
}
// /**
//  * 分页查询参数
//  */
// export interface PageQuery {
//   pageNum: number;
//   pageSize: number;
// }

// /**
//  * 分页响应对象
//  */
// export interface PageResult<T> {
//   /** 数据列表 */
//   list: T;
//   /** 总数 */
//   total: number;
// }