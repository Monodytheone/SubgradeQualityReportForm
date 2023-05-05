<template>
    <div v-title data-title="已提交列表" />
    <a-affix :offset-top="30">
        <a-button id="button-router" type="defualt" @click="jumpToSubmit">前往提交表单</a-button>
    </a-affix>
    <div class="background">
        <div class="displayRange">
            <h1 style="padding-top: 20px;">已提交列表</h1>
            <van-tabs v-model:active="activeName">
                <van-tab title="待处理" name="a">
                    <ListInStatus status="true" />
                </van-tab>

                <van-tab title="待完善" name="b">
                    <ListInStatus status="false" />
                </van-tab>
            </van-tabs>
        </div>
    </div>
</template>
<script lang="ts">
import { defineComponent, ref } from 'vue';
import ListInStatus from './components/ListInStatus.vue';
import router from '@/router';
export default defineComponent({
    components: {
        ListInStatus,
    },
    setup() {
        const activeName = ref('a');
        const jumpToSubmit = () => {
            router.push('/')
        }

        return {
            activeName,
            jumpToSubmit
        }
    }
})
</script>
<style scopde>
.background {
    background-color: #fbfaf9;
}

.displayRange {
    width: 1000px;
    margin: auto;
    background-color: aliceblue;
}

#button-router {
    right: 200px;
    background-color: #eeeeee;
    position: fixed;
}
</style>