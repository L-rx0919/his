import request from "@/utils/request";

/* 基础API URL*/
const PATIENTCENTER_BASE_URL = "/api/v2/his/patientChenter";
const patientChenterApi = {
  GetpatientChenterInfo(queryParams: queryDto) {
    return request<any, patientChenterInfo[]>({
      url: `${PATIENTCENTER_BASE_URL}/GetPatients`,
      method: "get",
      params: queryParams,
    });
  },
  GetChargingModule(queryParams: queryId) {
    return request<any, queryList[]>({
      url: `${PATIENTCENTER_BASE_URL}/GetChargingModule`,
      method: "get",
      params: queryParams,
    });
  },
};

export default patientChenterApi;

export interface patientChenterInfo {
  name: string | null;
  title: string | null;
  department_id: string;
  phone: string | null;
  specialty: string | null;
  key_department_name: string;
  key_department_location: string | null;
  key_department_phone: string | null;
  department_type: string;
  patientid: number;
  patient_name: string;
  patient_gender: string;
  patient_age: number;
  patient_contact: string | null;
  patient_address: string | null;
  patient_blood_type: string | null;
  emergency_contact: string | null;
  marital_status: string | null;
  card_status: string | null;
  card_type: string | null;
  balance: number;
  create_date: string; // Format: YYYY-MM-DDTHH:MM:SS
  expiry_date: string; // Format: YYYY-MM-DDTHH:MM:SS
  last_transaction_date: string; // Format: YYYY-MM-DDTHH:MM:SS
  card_owner_name: string | null;
  associated_dept: string | null;
  contact_phone: string | null;
  remarks: string | null;
}
export interface queryDto {
  patientName: string | null;
}

export interface queryId {
  id: string;
}
export interface queryList {
  templateName: string;
}
