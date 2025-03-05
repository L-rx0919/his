import request from "@/utils/request";
const Systemconfig_BASE_URL = "/api/v1/his/systemconfig";

const SystemconfigAPI = {
  //显示
  /**
   * 查询参数
   *
   * @param id 字典ID
   * @param data 字典表单数据
   */
  getForm() {
    return request<any, ChargingListDto[]>({
      url: `${Systemconfig_BASE_URL}/ChargingList`,
      method: "get",
      params: {},
    });
  },
};

export default SystemconfigAPI;

export interface ChargingListDto {
  departmentID: number;
  templateName: string;
  singltreatment: number;
  numberCutions: number;
  typeRehabil: number;
  parts: string;
  unittime: string;
}
