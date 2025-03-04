import request from "@/utils/request";

/* 基础API URL*/
const PATIENTCENTER_BASE_URL = "/api/v1/his/patientChenter";
const patientChenterApi = {
  GetDepartment() {
    return request<any, DepartmentPatientDto[]>({
      url: `${PATIENTCENTER_BASE_URL}/getDepartment`,
      method: "get",
      params: {},
    });
  },
};

export default patientChenterApi;

export interface DepartmentPatientDto {
  name: string;
  location: string;
  phone: string;
  department_type: string;
}
