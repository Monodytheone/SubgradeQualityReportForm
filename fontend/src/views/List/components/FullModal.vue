<template>
    <div>
        <!-- <a-button type="primary" @click="showModal">Open Modal</a-button> -->
        <a-modal v-model:visible="visible" :title="`${formDetail.expresswayName} 高速公路路基现场质量检验报告单`" width="100%"
            wrap-class-name="full-modal" @ok="handleOk">
            <div class="content-modal">
                <table class="table" border="1px" style="text-align: center;">
                    <tbody>
                        <th colspan="2">承包单位</th>
                        <td colsapn="4">{{ formDetail.contractorCompany }}</td>
                        <th colspan="1">合同号</th>
                        <td colspan="4">{{ formDetail.contractNumber }}</td>
                    </tbody>
                    <tbody>
                        <th colspan="2">监理单位</th>
                        <td colsapn="4">{{ formDetail.supervisionCompany }}</td>
                        <th colspan="1">编号</th>
                        <td colspan="4">{{ formDetail.serialNumber }}</td>
                    </tbody>
                    <tbody>
                        <th colspan="2">路基类型</th>
                        <td colspan="6">{{ formDetail.subgradeType === 1 ? "土方路基" : "石方路基" }}</td>

                    </tbody>

                    <tbody>
                        <th colspan="2">工程名称</th>
                        <td colspan="2">{{ formDetail.projectName }}</td>
                        <th>施工时间</th>
                        <td colspan="3">{{
                            `${formDetail.startDate.year}/${formDetail.startDate.month}/${formDetail.startDate.day} ~
                                                    ${formDetail.endDate.year}/${formDetail.endDate.month}/${formDetail.endDate.day}` }}</td>
                    </tbody>
                    <tbody>
                        <th colspan="2">桩号及部位</th>
                        <td colspan="2">{{ formDetail.stakeNumberAndLocation }}</td>
                        <th>检验时间</th>
                        <td colspan="3">{{
                            `${formDetail.inspectionDate.year}/${formDetail.inspectionDate.month}/${formDetail.inspectionDate.day}`
                        }}
                        </td>
                    </tbody>
                    <tbody>
                        <tr>
                            <th colspan="3">项次</th>
                            <th>检查项目</th>
                            <th>规定值或允许偏差</th>
                            <th>检查结果</th>
                            <th>检验结果附表代码</th>
                            <th>备注</th>
                        </tr>
                    </tbody>
                    <tbody>
                        <th>1Δ</th>
                        <th style="width: 2em">压实度或沉降差</th>
                        <th colspan="2">零填及路堑0~0.80m</th>
                        <td>{{ formDetail.rows[0].specifiedValueAndAllowableDeviation }}</td>
                        <td>{{ formDetail.rows[0].inspectionResult }}</td>
                        <td>{{ formDetail.rows[0].code }}</td>
                        <td>{{ formDetail.rows[0].note }}</td>
                    </tbody>
                    <tbody>
                        <th></th>
                        <th></th>
                        <th>轻、中及重载荷等级</th>
                        <th>0~0.80m</th>
                        <td>{{ formDetail.rows[1].specifiedValueAndAllowableDeviation }}</td>
                        <td>{{ formDetail.rows[1].inspectionResult }}</td>
                        <td>{{ formDetail.rows[1].code }}</td>
                        <td>{{ formDetail.rows[1].note }}</td>
                    </tbody>
                    <tbody>
                        <th></th>
                        <th></th>
                        <th>特重、极重载荷等级</th>
                        <th>0~1.20m</th>
                        <td>{{ formDetail.rows[2].specifiedValueAndAllowableDeviation }}</td>
                        <td>{{ formDetail.rows[2].inspectionResult }}</td>
                        <td>{{ formDetail.rows[2].code }}</td>
                        <td>{{ formDetail.rows[2].note }}</td>
                    </tbody>
                    <tbody>
                        <th></th>
                        <th></th>
                        <th>轻、中及重载荷等级</th>
                        <th>0.80~1.50m</th>
                        <td>{{ formDetail.rows[3].specifiedValueAndAllowableDeviation }}</td>
                        <td>{{ formDetail.rows[3].inspectionResult }}</td>
                        <td>{{ formDetail.rows[3].code }}</td>
                        <td>{{ formDetail.rows[3].note }}</td>
                    </tbody>
                    <tbody>
                        <th></th>
                        <th></th>
                        <th>特重、极重载荷等级</th>
                        <th>1.20~1.90m</th>
                        <td>{{ formDetail.rows[4].specifiedValueAndAllowableDeviation }}</td>
                        <td>{{ formDetail.rows[4].inspectionResult }}</td>
                        <td>{{ formDetail.rows[4].code }}</td>
                        <td>{{ formDetail.rows[4].note }}</td>
                    </tbody>
                    <tbody>
                        <th></th>
                        <th></th>
                        <th>轻、中及重载荷等级</th>
                        <th>>1.50m</th>
                        <td>{{ formDetail.rows[5].specifiedValueAndAllowableDeviation }}</td>
                        <td>{{ formDetail.rows[5].inspectionResult }}</td>
                        <td>{{ formDetail.rows[5].code }}</td>
                        <td>{{ formDetail.rows[5].note }}</td>
                    </tbody>
                    <tbody>
                        <th></th>
                        <th></th>
                        <th>特重、极重载荷等级</th>
                        <th>>1.90m</th>
                        <td>{{ formDetail.rows[6].specifiedValueAndAllowableDeviation }}</td>
                        <td>{{ formDetail.rows[6].inspectionResult }}</td>
                        <td>{{ formDetail.rows[6].code }}</td>
                        <td>{{ formDetail.rows[6].note }}</td>
                    </tbody>
                    <tbody>
                        <th>2Δ</th>
                        <th colspan="3">弯沉（0.01mm）</th>
                        <td>{{ formDetail.rows[7].specifiedValueAndAllowableDeviation }}</td>
                        <td>{{ formDetail.rows[7].inspectionResult }}</td>
                        <td>{{ formDetail.rows[7].code }}</td>
                        <td>{{ formDetail.rows[7].note }}</td>
                    </tbody>
                    <tbody v-for="(item, index) in formDetail.rows.slice(8)">
                        <th></th>
                        <th colspan="3">弯沉（0.01mm）</th>
                        <td>{{ formDetail.rows[7].specifiedValueAndAllowableDeviation }}</td>
                        <td>{{ formDetail.rows[7].inspectionResult }}</td>
                        <td>{{ formDetail.rows[7].code }}</td>
                        <td>{{ formDetail.rows[7].note }}</td>
                    </tbody>
                    <tbody>
                        <td colspan="8" style="text-align: left;">
                            <h3><b>监理意见：</b></h3>
                            <div class="opinionText">
                                <p v-if="formDetail.isQualified"><li>各项指标符合设计及规范要求</li></p>
                                <p v-if="formDetail.isQualified === false">{{ formDetail.unqualifiedItems }} 不符合设计及规范要求</p>
                                <step-forward-outlined />
                            </div>
                            <div class="signAndDate">
                                <p>专业监理工程师：{{ formDetail.supervisorName }}
                                    <span>{{ `${formDetail.signingDate.year} 年 ${formDetail.signingDate.month} 月
                                                                            ${formDetail.signingDate.day} 日` }}
                                    </span>
                                </p>
                            </div>
                        </td>
                    </tbody>
                </table>
            </div>
        </a-modal>
    </div>
</template>
<script lang="ts">
import { defineComponent, ref } from 'vue';
import getForm from '@/apis/getForm';
import SubgradeType from '@/types/SubgradeType';
import FormDetail from '@/types/FormDetail';
import { reactive } from 'vue';
export default defineComponent({
    setup(props, { expose }) {
        const formDetail = ref({
            expresswayName: '',
            contractorCompany: '',
            supervisionCompany: '',
            contractNumber: '',
            serialNumber: '',
            subgradeType: SubgradeType.Unset,
            projectName: '',
            stakeNumberAndLocation: '',
            startDate: {
                year: 0,
                month: 0,
                day: 0
            },
            endDate: {
                year: 0,
                month: 0,
                day: 0
            },
            inspectionDate: {
                year: 0,
                month: 0,
                day: 0
            },
            rows: [
                {
                    specifiedValueAndAllowableDeviation: '',
                    inspectionResult: '',
                    code: '',
                    note: '',
                },
                {
                    specifiedValueAndAllowableDeviation: '',
                    inspectionResult: '',
                    code: '',
                    note: '',
                },
                {
                    specifiedValueAndAllowableDeviation: '',
                    inspectionResult: '',
                    code: '',
                    note: '',
                },
                {
                    specifiedValueAndAllowableDeviation: '',
                    inspectionResult: '',
                    code: '',
                    note: '',
                },
                {
                    specifiedValueAndAllowableDeviation: '',
                    inspectionResult: '',
                    code: '',
                    note: '',
                },
                {
                    specifiedValueAndAllowableDeviation: '',
                    inspectionResult: '',
                    code: '',
                    note: '',
                },
                {
                    specifiedValueAndAllowableDeviation: '',
                    inspectionResult: '',
                    code: '',
                    note: '',
                },
                {
                    specifiedValueAndAllowableDeviation: '',
                    inspectionResult: '',
                    code: '',
                    note: '',
                },

            ],
            isQualified: false,
            unqualifiedItems: '',
            supervisorName: '',
            signingDate: {
                year: 0,
                month: 0,
                day: 0
            },

        })



        // 表格框显示的管理：
        const visible = ref<boolean>(false);
        const showModal = (formId: string) => {
            visible.value = true;
            getForm(formId)
                .then(response => {
                    formDetail.value = response.data
                    console.log(formDetail)
                })
                .catch(error => {

                })
        };
        const handleOk = (e: MouseEvent) => {
            visible.value = false;
        };
        expose({ showModal });

        return {
            visible,
            formDetail,
            showModal,
            handleOk,
        };
    },
});
</script>
<style lang="less">
.full-modal {
    .ant-modal {
        max-width: 90%;
        top: 0;
        padding-bottom: 0;
        // margin: 0;
        margin: auto;
    }

    .ant-modal-content {
        display: flex;
        flex-direction: column;
        height: calc(100vh);
    }

    .ant-modal-body {
        flex: 1;
    }
}

.content-modal {
    margin-left: 200px;
}

.opinionText {
    position: relative;
    left: 100px;
}

.signAndDate {
    margin-left: 300px;
    p {
        margin-bottom: 0;
    }
    span {
        margin-left: 20px;
    }
}
</style>
  