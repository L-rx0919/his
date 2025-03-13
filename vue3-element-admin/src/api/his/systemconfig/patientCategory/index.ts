import request from "@/utils/request";

const Systemconfig_BASE_URL = "/api/v2/his/systemconfig/patientCategory";

const SystemconfigAPI = {
  /**
   * 新增
   *
   * @param data 字典表单数据
   */
  addConfing(data: AdDSystemconfig) {
    return request({
      url: `${Systemconfig_BASE_URL}/NatureofPatient`,
      method: "post",
      data: data,
    });
  },
  /**
   * 查询参数
   *
   * @param id 字典ID
   * @param data 字典表单数据
   */
  getForm() {
    return request<any, NatureofPatientListDto[]>({
      url: `${Systemconfig_BASE_URL}/NatureofPatientList`,
      method: "get",
      params: {},
    });
  },

  /**
   * 删除病人性质
   *
   * @param id 病人性质ID
   */
  deleteConfig(id: string) {
    return request({
      url: `${Systemconfig_BASE_URL}/NatureofPatientDel/${id}`,
      method: "delete",
    });
  },
};

export default SystemconfigAPI;

// 添加病人性质
export interface AdDSystemconfig {
  concurrencyStamp: string;
  creationTime: string;
  creatorId: string;
  lastModificationTime: string;
  lastModifierId: string;
  isDeleted: boolean;
  deleterId: string;
  deletionTime: string;
  natureofPatientName: string;
  naturecode: string;
  typeinsurance: string;
  hospitallogo: string;
  status: string;
  natureTypeCard: string;
  medicaltype: string;
  remarks: string;
}

// 查询显示病人性质
export interface NatureofPatientListDto {
  natureofPatientName: string;
  naturecode: string;
  typeinsurance: string;
  hospitallogo: string;
  status: string;
  natureTypeCard: string;
  medicaltype: string;
  remarks: string;
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
