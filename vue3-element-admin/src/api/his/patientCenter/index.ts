import request from "@/utils/request";

/* 基础API URL*/
const PATIENTCENTER_BASE_URL = "/api/v2/his/patientChenter";
const patientChenterApi = {
  GetpatientChenterInfo() {
    return request<any, patientChenterInfo[]>({
      url: `${PATIENTCENTER_BASE_URL}/getpatientChenterInfo`,
      method: "get",
      params: {},
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
