import request from "@/utils/request";

/* 基础API URL*/
const PATIENT_BASE_URL = "/api/v1/his/patient";

const PatientAPI = {
  /**
   * 获取患者列表
   *
   * @param queryParams 查询参数
   * @returns 字典分页结果
   */
  getList(queryParams: patientQuery) {
    return request<any, PatientDto[]>({
      url: `${PATIENT_BASE_URL}/page`,
      method: "get",
      params: queryParams,
    });
  },
  /**
   * 获取患者列表
   *
   * @param queryParams 查询参数
   * @returns 字典分页结果
   */
  GetPatientNameAndId() {
    return request<any, GetPatientNameAndIdDto[]>({
      url: `${PATIENT_BASE_URL}/getPatientNameAndId`,
      method: "get",
      params: {},
    });
  },
  getPatientCardInfos() {
    return request<any, PatientCardInfoList[]>({
      url: `${PATIENT_BASE_URL}/getPatientCardInfos`,
      method: "get",
      params: {},
    });
  },
  /**
   * 获取患者详情
   *
   * @param patientCardInfo 一卡通信息
   * @returns 返回一卡通
   */
  insertPatientCardInfo(data: PatientCardInfo) {
    return request({
      url: `${PATIENT_BASE_URL}/insertPatientCardInfo`,
      method: "post",
      data: data, // 传递 PatientCardInfo 对象
    });
  },
  GetDepartment() {
    return request<any, GetDepartmentDto[]>({
      url: `${PATIENT_BASE_URL}/getDepartment`,
      method: "get",
      params: {},
    });
  },
};
export default PatientAPI;

export interface patientQuery {
  name?: string | undefined;
  phone?: string | undefined;
}

export interface PatientDto {
  patient_name: string; // 患者姓名
  patient_gender: string; // 患者性别
  patient_age: number; // 患者年龄
  patient_contact: string; // 患者联系方式
  patient_address: string; // 患者地址
  patient_blood_type: string; // 患者血型
  emergency_contact: string | null; // 紧急联系人
  marital_status: string | null; // 婚姻状态
  isDeleted: boolean; // 是否删除
  deleterId: string | null; // 删除者ID
  deletionTime: string | null; // 删除时间
  lastModificationTime: string | null; // 最后修改时间
  lastModifierId: string | null; // 最后修改者ID
  creationTime: string; // 创建时间
  creatorId: string | null; // 创建者ID
  extraProperties: Record<string, any>; // 额外属性
  concurrencyStamp: string; // 并发戳记
  id: string; // ID
}

export interface PatientCardInfo {
  concurrencyStamp: string;
  creationTime: string; // ISO 8601 格式的时间字符串
  creatorId: string;
  lastModificationTime: string; // ISO 8601 格式的时间字符串
  lastModifierId: string;
  isDeleted: boolean;
  deleterId: string;
  deletionTime: string; // ISO 8601 格式的时间字符串
  patient_id: string;
  card_status: string;
  card_type: string;
  balance: number;
  create_date: string; // ISO 8601 格式的时间字符串
  expiry_date: string; // ISO 8601 格式的时间字符串
  last_transaction_date: string; // ISO 8601 格式的时间字符串
  card_owner_name: string;
  associated_dept: string;
  contact_phone: string;
  remarks: string;
}
export interface GetPatientNameAndIdDto {
  patient_name: string; // 患者姓名
  id: string; // 患者ID
}
export interface PageResult<T> {
  list: T[];
  total: number;
}
export interface PatientCardInfoList {
  concurrencyStamp: string;
  creationTime: string; // ISO 8601 格式的时间字符串
  creatorId: string;
  lastModificationTime: string; // ISO 8601 格式的时间字符串
  lastModifierId: string;
  isDeleted: boolean;
  deleterId: string;
  deletionTime: string; // ISO 8601 格式的时间字符串
  patient_id: string;
  card_status: string;
  card_type: string;
  balance: number;
  create_date: string; // ISO 8601 格式的时间字符串
  expiry_date: string; // ISO 8601 格式的时间字符串
  last_transaction_date: string; // ISO 8601 格式的时间字符串
  card_owner_name: string;
  associated_dept: string;
  contact_phone: string;
  remarks: string;
}
export interface GetDepartmentDto {
  id: string; // 科室ID
  name: string; // 科室名称
}
