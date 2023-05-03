import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import Antd from 'ant-design-vue';
import 'ant-design-vue/dist/antd.css';

const app = createApp(App);
app.use(router);
app.mount("#app");
app.use(Antd);

// 页面title
app.directive('title', {
	mounted(el){
		document.title = el.dataset.title
	}
});
