import request from "../../../utils/request";

/* 基础API URL*/
const OUTPATIENT_BASE_URL = "/api/v1/his/Outpatient";

const OutpatientAPI = {
  /**
   * 获取患者列表
   *
   * @param queryParams 查询参数
   * @returns 字典分页结果
   */
  getList(queryParams: OutpatientQuery) {
    return request<any, PatientDto[]>({
      url: `${OUTPATIENT_BASE_URL}/page`,
      method: "get",
      params: queryParams,
    });
  },
};
export interface OutpatientQuery {
  name?: string | undefined;
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
  deleterId: string;
  deletionTime: string;
  lastModificationTime: string;
  lastModifierId: string;
  creationTime: string;
  creatorId: string;
  extraProperties: Record<string, any>;
  concurrencyStamp: string;
  id: string;
}
