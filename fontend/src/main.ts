import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import Antd from 'ant-design-vue';
import 'ant-design-vue/dist/antd.css';
import { Tab, Tabs } from 'vant';

const app = createApp(App);

// 页面title
app.directive('title', {
	mounted(el){
		document.title = el.dataset.title
	}
});

app.use(router);
app.mount("#app");
app.use(Antd);


// Vant组件：
app.use(Tab);
app.use(Tabs);
