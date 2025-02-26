/**
 * 响应码枚举
 */
export const enum ResultEnum {
  /**
   * 成功
   */
  SUCCESS = 0,
  /**
   * 错误
   */
  ERROR = 1,

  /**
   * 访问令牌无效或过期
   */
  ACCESS_TOKEN_INVALID = 2,

  /**
   * 刷新令牌无效或过期
   */
  REFRESH_TOKEN_INVALID = 3,
}
