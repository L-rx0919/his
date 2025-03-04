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
  getList(queryParams: inpatientRecordAPIQuery) {
    return request<any, InpatientRecordDto>({
      url: `${InpatientRecord_BASE_URL}/page`,
      method: "get",
      params: queryParams,
    });
  },
};

export default InpatientRecordAPI;

export interface inpatientRecordAPIQuery {
  patient_id?: string | undefined;
}

export interface InpatientRecordDto {
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
