<template>
  <div id="app">
    <h1>SignalR Client in Vue 3</h1>
    <button @click="sendMessageToServer">Send Message</button>
  </div>
</template>

<script>
import { signalRService } from "./signalrService";

export default {
  name: "App",
  mounted() {
    // 初始化 SignalR 连接
    signalRService.initConnection();
  },
  methods: {
    sendMessageToServer() {
      // 发送消息到 SignalR Hub
      signalRService.sendMessage("Hello from Vue 3 client!");
    },
  },
};
</script>

<style>
/* Add your styles here */
</style>
