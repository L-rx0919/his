import request from "@/utils/request";

const SMSAPI = {
  sendSms(phoneNumber: dto) {
    return request({
      url: "/api/v2/his/sms/sendSmsAsync",
      method: "get",
      params: phoneNumber,
    });
  },
};

export default SMSAPI;

// Below is the code of e:\HIS\his\vue3-element-admin\src\api\his\sms\dto.ts
export interface dto {
  phoneNumber: string;
}
