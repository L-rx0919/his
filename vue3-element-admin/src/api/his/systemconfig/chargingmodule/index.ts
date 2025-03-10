import request from "@/utils/request";
const chargingmodule_BASE_URL = "/api/v1/his/systemconfig/chargingmodule";

const chargingmoduleAPI = {
  //显示
  /**
   * 查询参数`
   *
   * @param id 字典ID
   * @param data 字典表单数据
   */
  getForm() {
    return request<any, ChargingListDto[]>({
      url: `${chargingmodule_BASE_URL}/chargingList`,
      method: "get",
      params: {},
    });
  },

  /**
   * 新增
   *
   * @param data 字典表单数据
   */
  addChargingModule(data: addChargingModules) {
    return request({
      url: `${chargingmodule_BASE_URL}/chargingPatient`,
      method: "post",
      data: data,
    });
  },
};

export default chargingmoduleAPI;

//显示
export interface ChargingListDto {
  departmentID: number;
  templateName: string;
  singltreatment: number;
  numberCutions: number;
  typeRehabil: number;
  parts: string;
  unittime: string;
  departmentName: string;
  name: string;
  location: string;
  phone: string;
  department_type: string;
}

//新增
export interface addChargingModules {
  departmentID: number;
  templateName: string;
  singltreatment: number;
  numberCutions: number;
  typeRehabil: number;
  parts: string;
  unittime: string;
  departmentName: string;
  name: string;
  location: string;
  phone: string;
  department_type: string;
}
