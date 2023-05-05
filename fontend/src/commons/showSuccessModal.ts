import router from '@/router';
import { Modal } from 'ant-design-vue';

/** 展示成功提示框并刷新页面 */
export default function (message: string) {
    let secondsToGo = 5;
    let hasJumped: boolean = false  // 是否已经跳转过页面了
    const modal = Modal.warning({
        title: message,
        content: `${secondsToGo} 秒后跳转至登录页`,
        okText: '确定',
        onOk: function () {
            location.reload()
            hasJumped = true
        }
    });
    const interval = setInterval(() => {
        secondsToGo -= 1;
        modal.update({
            content: `${secondsToGo} 秒后跳转至登录页`,
        });
    }, 1000);
    setTimeout(() => {
        clearInterval(interval);
        modal.destroy();
        if (hasJumped === false) {
            location.reload()
        }
    }, secondsToGo * 1000);
}