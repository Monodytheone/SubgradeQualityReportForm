<template>
    <div v-title data-title="表单填写" />
    <div class="background">
        <div class="white-background">
            <div style="padding-top: 50px;" />
            <p class="header">
                <a-input id="input-expresswayName" v-model:value="value" placeholder="请输入公路名称" />高速公路路基现场质量检验报告单
            </p>
            <div style="margin-top: 50px;" />

            <div class="content">
                <a-form class="row" layout="inline">
                    <a-form-item label="承包单位">
                        <a-input placeholder="请输入承包单位"></a-input>
                    </a-form-item>
                    <a-form-item label="合同号" style="margin-left: 162px">
                        <a-input placeholder="请输入合同号"></a-input>
                    </a-form-item>
                </a-form>

                <a-form layout="inline">
                    <a-form-item label="监理单位">
                        <a-input placeholder="输入监理单位"></a-input>
                    </a-form-item>
                    <a-form-item label="编号" style="margin-left: 176px">
                        <a-input placeholder="输入编号"></a-input>
                    </a-form-item>
                </a-form>

                <a-form layout="inline">
                    <a-form-item class="row" label="路基类型">
                        <a-radio-group style="margin-left: 20px">
                            <a-radio value="1">土方路基</a-radio>
                            <a-radio value="2">石方路基</a-radio>
                        </a-radio-group>
                    </a-form-item>
                </a-form>

                <a-form class="row" layout="inline">
                    <a-form-item label="工程名称">
                        <a-input placeholder="请输入工程名称" />
                    </a-form-item>
                    <a-form-item label="桩号及部位" style="margin-left: 134px">
                        <a-input placeholder="桩号及部位" />
                    </a-form-item>
                </a-form>

                <a-form class="row" layout="inline">
                    <a-form-item label="施工时间">
                        <a-range-picker v-model:value="value1" :locale="locale" />
                    </a-form-item>

                    <a-form-item label="检验时间" style="margin-left: 40px">
                        <a-date-picker v-model:value="inspectionDate" :locale="locale" />
                    </a-form-item>
                </a-form>
            </div>

            <table class="table" border="1px">
                <thead>
                    <tr>
                        <th colspan="3">项次</th>
                        <th>检查项目</th>
                        <th>规定值或允许偏差</th>
                        <th>检查结果</th>
                        <th>检验结果附表代码</th>
                        <th>备注（可选）</th>
                    </tr>
                </thead>
                <tbody>
                    <th>1Δ</th>
                    <th style="width: 2em">压实度或沉降差</th>
                    <th colspan="2">零填及路堑0~0.80m</th>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>轻、中及重载荷等级</th>
                    <th>0~0.80m</th>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>特重、极重载荷等级</th>
                    <th>0~1.20m</th>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>轻、中及重载荷等级</th>
                    <th>0.80~1.50m</th>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>特重、极重载荷等级</th>
                    <th>1.20~1.90m</th>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>轻、中及重载荷等级</th>
                    <th>>1.50m</th>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>特重、极重载荷等级</th>
                    <th>>1.90m</th>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" /></td>
                </tbody>

                <tbody>
                    <th>2Δ</th>
                    <th colspan="3">弯沉（0.01mm）</th>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" /></td>
                </tbody>
                <tbody v-for="item in arr">
                    <th></th>
                    <th colspan="3">弯沉（0.01mm）</th>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" /></td>
                </tbody>

            </table>
            <div class="buttons">
                <a-button type="primary" ghost :disabled="arr.length > 9" @click="addDeflection">增加一组弯沉</a-button>
                <a-button id="button-deleteDeflection" danger :disabled="arr.length === 0"
                    @click="deleteDeflection">删除最后一组弯沉</a-button>
            </div>
            <div class="content">
                <a-form layout="inline">
                    <a-form-item label="是否合格">
                        <a-radio-group v-model:value="isQualified">
                            <a-radio :style="radioStyle" :value="true">各项指标符合设计及规范要求</a-radio>
                            <a-radio :style="radioStyle" :value="false">
                                <p style="text-align: left;">不合格</p>
                                <div v-if="isQualified === false">
                                    <a-input style="width: 150px; margin-left: 10px" placeholder="请输入不合格项" />
                                    不符合设计及规范要求
                                </div>
                            </a-radio>
                        </a-radio-group>
                    </a-form-item>
                </a-form>
                <a-form layout="inline" style="margin-top: 100px">
                    <a-form-item label="专业监理工程师">
                        <a-input placeholder="请输入监理姓名"></a-input>
                    </a-form-item>
                    <a-form-item label="监理签字日期">
                        <a-date-picker v-model:value="value1" :locale="locale" />
                    </a-form-item>

                </a-form>
            </div>
            <div style="padding-top: 500px" />
        </div>
    </div>
</template>
<script lang="ts">
import { defineComponent, reactive, ref } from 'vue';
import 'dayjs/locale/zh-cn';
import dayjs from 'dayjs';
import type { Dayjs } from 'dayjs';
import locale from 'ant-design-vue/es/date-picker/locale/zh_CN';
import FormDetail from '@/types/FormDetail';
import DateInfo from '@/types/DateInfo';
dayjs.locale('zh-cn');
export default defineComponent({
    setup() {

        const arr = reactive<number[]>([])
        const isQualified = ref<boolean>();
        const radioStyle = reactive({
            display: 'flex',
            height: '30px',
            lineHeight: '30px',
        });

        const formState = reactive<FormDetail>({
            ExpresswayName: '',
            ContractorCompany: '',
            SupervisionCompany: '',
            ContractNumber: '',
            SerialNumber: '',
            SubgradeType: 0,
            ProjectName: '',
            StakeNumberAndLocation: '',
            StartDate: undefined,
            EndDate: undefined,
            InspectionDate: undefined,
            Items: InspectionDetail[],
            IsQualified: false,
            UnqualifiedItems?: undefined,
            SupervisorName: '',
            SigningDate: undefined,
        })
        const inspectionDate = ref<Dayjs>()

        const addDeflection = () => {
            arr.unshift(1)
        }

        const deleteDeflection = () => {
            arr.splice(arr.length - 1, 1)
        }

        return {
            arr,
            locale,
            radioStyle,
            isQualified,
            inspectionDate,
            addDeflection,
            deleteDeflection
        }
    }
})
</script>
<style scoped>
.background {
    background-color: #fbfaf9;
}

.white-background {
    width: 1000px;
    margin: auto;
    background-color: white;
}

#input-expresswayName {
    width: 150px;
    margin-right: 10px;
    font-size: 18px;
    text-align: center;
}

.header {
    font-size: 30px;
    font-weight: bolder;
}

.content {
    margin-left: 50px;
}

.row {
    margin: 10px 0;
}

.table {
    margin: 50px 20px 10px;
}

.buttons {
    margin-bottom: 50px;
}

#button-deleteDeflection {
    margin-left: 50px;
}
</style>
