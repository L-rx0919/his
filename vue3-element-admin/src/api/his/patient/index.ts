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
    return request<any, PageResult<PatientDto>>({
      url: `${PATIENT_BASE_URL}/page`,
      method: "get",
      params: queryParams,
    });
  },
};

export default PatientAPI;

export interface patientQuery {
  name?: string | undefined;
  phone?: string | undefined;
}

export interface PatientDto {
  patient_name: string;
  patient_gender: string;
  patient_age: number;
  patient_contact: string;
  patient_address: string;
  patient_blood_type: string;
  emergency_contact: string;
  marital_status: string;
  isDeleted: boolean;
  deleterId: string | null;
  deletionTime: string | null;
  lastModificationTime: string | null;
  lastModifierId: string | null;
  creationTime: string;
  creatorId: string | null;
  extraProperties: Record<string, any>;
  concurrencyStamp: string;
  id: string;
}

export interface PageResult<T> {
  list: T[];
  total: number;
}
