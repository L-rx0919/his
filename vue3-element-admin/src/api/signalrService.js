// signalrService.js
import { HubConnectionBuilder } from "@microsoft/signalr";

class SignalRService {
  constructor() {
    this.connection = null;
  }

  // 初始化 SignalR 连接
  initConnection() {
    this.connection = new HubConnectionBuilder().withUrl("/myHub").build();

    this.connection.on("ReceiveMessage", (message) => {
      console.log("Received message:", message);
    });

    this.connection
      .start()
      .then(() => {
        console.log("Connected to SignalR Hub!");
      })
      .catch((err) => {
        console.error("Error connecting to SignalR Hub:", err);
      });
  }

  // 向服务器发送消息
  sendMessage(message) {
    if (this.connection) {
      this.connection.invoke("SendMessage", message).catch((err) => {
        console.error("Error sending message:", err);
      });
    }
  }
}

export const signalRService = new SignalRService();
