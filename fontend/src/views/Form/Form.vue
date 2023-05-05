<template>
    <div v-title data-title="表单填写" />
    <div class="background">
        <div class="white-background">
            <div style="padding-top: 50px;" />
            <p class="header">
                <a-input id="input-expresswayName" v-model:value="formState.ExpresswayName"
                    placeholder="请输入公路名称" />高速公路路基现场质量检验报告单
            </p>
            <div style="margin-top: 50px;" />

            <div class="content">
                <a-form class="row" layout="inline">
                    <a-form-item label="承包单位">
                        <a-input placeholder="请输入承包单位" v-model:value="formState.ContractorCompany"></a-input>
                    </a-form-item>
                    <a-form-item label="合同号" style="margin-left: 162px">
                        <a-input placeholder="请输入合同号" v-model:value="formState.ContractNumber"></a-input>
                    </a-form-item>
                </a-form>

                <a-form layout="inline">
                    <a-form-item label="监理单位">
                        <a-input placeholder="输入监理单位" v-model:value="formState.SupervisionCompany"></a-input>
                    </a-form-item>
                    <a-form-item label="编号" style="margin-left: 176px">
                        <a-input placeholder="输入编号" v-model:value="formState.SerialNumber"></a-input>
                    </a-form-item>
                </a-form>

                <a-form layout="inline">
                    <a-form-item class="row" label="路基类型">
                        <a-radio-group style="margin-left: 20px" v-model:value="formState.SubgradeType">
                            <a-radio :value="1">土方路基</a-radio>
                            <a-radio :value="2">石方路基</a-radio>
                        </a-radio-group>
                    </a-form-item>
                </a-form>

                <a-form class="row" layout="inline">
                    <a-form-item label="工程名称">
                        <a-input placeholder="请输入工程名称" v-model:value="formState.ProjectName" />
                    </a-form-item>
                    <a-form-item label="桩号及部位" style="margin-left: 134px">
                        <a-input placeholder="桩号及部位" v-model:value="formState.StakeNumberAndLocation" />
                    </a-form-item>
                </a-form>

                <a-form class="row" layout="inline">
                    <a-form-item label="施工时间">
                        <a-range-picker v-model:value="constructionDateRange" :locale="locale" />
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
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[0].SpecifiedValueAndAllowableDeviation" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[0].InspectionResult" />
                    </td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[0].Code" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" v-model:value="formState.Items[0].Note" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>轻、中及重载荷等级</th>
                    <th>0~0.80m</th>
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[1].SpecifiedValueAndAllowableDeviation" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[1].InspectionResult" />
                    </td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[1].Code" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" v-model:value="formState.Items[1].Note" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>特重、极重载荷等级</th>
                    <th>0~1.20m</th>
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[2].SpecifiedValueAndAllowableDeviation" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[2].InspectionResult" />
                    </td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[2].Code" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" v-model:value="formState.Items[2].Note" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>轻、中及重载荷等级</th>
                    <th>0.80~1.50m</th>
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[3].SpecifiedValueAndAllowableDeviation" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[3].InspectionResult" />
                    </td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[3].Code" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" v-model:value="formState.Items[3].Note" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>特重、极重载荷等级</th>
                    <th>1.20~1.90m</th>
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[4].SpecifiedValueAndAllowableDeviation" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[4].InspectionResult" />
                    </td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[4].Code" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" v-model:value="formState.Items[4].Note" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>轻、中及重载荷等级</th>
                    <th>>1.50m</th>
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[5].SpecifiedValueAndAllowableDeviation" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[5].InspectionResult" />
                    </td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[5].Code" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" v-model:value="formState.Items[5].Note" /></td>
                </tbody>
                <tbody>
                    <th></th>
                    <th></th>
                    <th>特重、极重载荷等级</th>
                    <th>>1.90m</th>
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[6].SpecifiedValueAndAllowableDeviation" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[6].InspectionResult" />
                    </td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[6].Code" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" v-model:value="formState.Items[6].Note" /></td>
                </tbody>

                <tbody>
                    <th>2Δ</th>
                    <th colspan="3">弯沉（0.01mm）</th>
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[7].SpecifiedValueAndAllowableDeviation" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[7].InspectionResult" />
                    </td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[7].Code" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" v-model:value="formState.Items[7].Note" /></td>
                </tbody>
                <tbody v-for="(item, index) in formState.Items.slice(8)">
                    <th></th>
                    <th colspan="3">弯沉（0.01mm）</th>
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[8 + index].SpecifiedValueAndAllowableDeviation" /></td>
                    <td><a-input :bordered="false" placeholder="请输入"
                            v-model:value="formState.Items[8 + index].InspectionResult" /></td>
                    <td><a-input :bordered="false" placeholder="请输入" v-model:value="formState.Items[8 + index].Code" /></td>
                    <td><a-input :bordered="false" placeholder="请输入（可选）" v-model:value="formState.Items[8 + index].Note" />
                    </td>
                </tbody>

            </table>
            <div class="buttons">
                <a-button type="primary" ghost :disabled="formState.Items.length > 17"
                    @click="addDeflection">增加一组弯沉</a-button>
                <a-button id="button-deleteDeflection" danger :disabled="formState.Items.length === 8"
                    @click="deleteDeflection">删除最后一组弯沉</a-button>
            </div>
            <div class="content">
                <a-form layout="inline">
                    <a-form-item label="是否合格">
                        <a-radio-group v-model:value="formState.IsQualified">
                            <a-radio :style="radioStyle" :value="true">各项指标符合设计及规范要求</a-radio>
                            <a-radio :style="radioStyle" :value="false">
                                <p style="text-align: left;">不合格</p>
                                <div v-if="formState.IsQualified === false">
                                    <a-input v-model:value="formState.UnqualifiedItems"
                                        style="width: 150px; margin-left: 10px" placeholder="请输入不合格项" />
                                    不符合设计及规范要求
                                </div>
                            </a-radio>
                        </a-radio-group>
                    </a-form-item>
                </a-form>
                <a-form layout="inline" style="margin-top: 100px">
                    <a-form-item label="专业监理工程师">
                        <a-input placeholder="请输入监理姓名" v-model:value="formState.SupervisorName"></a-input>
                    </a-form-item>
                    <a-form-item label="监理签字日期">
                        <a-date-picker v-model:value="supervisionDate" :locale="locale" />
                    </a-form-item>

                </a-form>

                <a-button id="button-submit" type="primary" size="large" :loading="submitButtonIsLoading" @click="handleSubmit">{{
                    submitButtonIsLoading ? "提交中" : "提交表单" }}</a-button>
            </div>
            <div style="padding-top: 500px" />
        </div>
    </div>
</template>
<script lang="ts">
import { defineComponent, reactive, ref, watch, watchEffect } from 'vue';
import 'dayjs/locale/zh-cn';
import dayjs from 'dayjs';
import type { Dayjs } from 'dayjs';
import locale from 'ant-design-vue/es/date-picker/locale/zh_CN';
import FormDetail from '@/types/FormDetail';
import DateInfo from '@/types/DateInfo';
import SubgradeType from '@/types/SubgradeType';
import { message } from 'ant-design-vue';
import submit from '@/apis/submit';
import showErrorModal from '@/commons/showErrorModal';
import showSuccessModalAndReload from '@/commons/showSuccessModal';
dayjs.locale('zh-cn');
type RangeValue = [Dayjs, Dayjs];
export default defineComponent({
    setup() {
        const arr = reactive<number[]>([])
        const isQualified = ref<boolean>();
        const radioStyle = reactive({
            display: 'flex',
            height: '30px',
            lineHeight: '30px',
        });
        const submitButtonIsLoading = ref(false)

        // 从表单读取时间为dayjs，并把dayjs转换为DateInfo
        const constructionDateRange = ref<RangeValue>();
        const inspectionDate = ref<Dayjs>()
        const supervisionDate = ref<Dayjs>()
        watch(constructionDateRange, () => {
            if (constructionDateRange.value != undefined) {
                formState.StartDate = {
                    Year: constructionDateRange.value[0].year(),
                    Month: constructionDateRange.value[0].month() + 1,  // dayjs的month的范围是0-11
                    Day: constructionDateRange.value[0].date(),  // dayjs的day表示的是一周中的第几天，取日期应该用date
                };
                formState.EndDate = {
                    Year: constructionDateRange.value[1].year(),
                    Month: constructionDateRange.value[1].month() + 1,
                    Day: constructionDateRange.value[1].date(),
                };
            }
        });
        watch(inspectionDate, () => {
            if (inspectionDate.value != undefined) {
                formState.InspectionDate = {
                    Year: inspectionDate.value.year(),
                    Month: inspectionDate.value.month() + 1,
                    Day: inspectionDate.value.date()
                };
            }
        });
        watch(supervisionDate, () => {
            if (supervisionDate.value != undefined) {
                formState.SigningDate = {
                    Year: supervisionDate.value.year(),
                    Month: supervisionDate.value.month() + 1,
                    Day: supervisionDate.value.date(),
                };
            }
        });


        const formState = reactive<FormDetail>({
            ExpresswayName: '',
            ContractorCompany: '',
            SupervisionCompany: '',
            ContractNumber: '',
            SerialNumber: '',
            SubgradeType: SubgradeType.Unset,
            ProjectName: '',
            StakeNumberAndLocation: '',
            StartDate: undefined,
            EndDate: undefined,
            InspectionDate: undefined,
            Items: [
                {
                    SpecifiedValueAndAllowableDeviation: '',
                    InspectionResult: '',
                    Code: '',
                    Note: '',
                },
                {
                    SpecifiedValueAndAllowableDeviation: '',
                    InspectionResult: '',
                    Code: '',
                    Note: '',
                },
                {
                    SpecifiedValueAndAllowableDeviation: '',
                    InspectionResult: '',
                    Code: '',
                    Note: '',
                },
                {
                    SpecifiedValueAndAllowableDeviation: '',
                    InspectionResult: '',
                    Code: '',
                    Note: '',
                },
                {
                    SpecifiedValueAndAllowableDeviation: '',
                    InspectionResult: '',
                    Code: '',
                    Note: '',
                },
                {
                    SpecifiedValueAndAllowableDeviation: '',
                    InspectionResult: '',
                    Code: '',
                    Note: '',
                },
                {
                    SpecifiedValueAndAllowableDeviation: '',
                    InspectionResult: '',
                    Code: '',
                    Note: '',
                },
                {
                    SpecifiedValueAndAllowableDeviation: '',
                    InspectionResult: '',
                    Code: '',
                    Note: '',
                },

            ],
            IsQualified: undefined,
            UnqualifiedItems: '',
            SupervisorName: '',
            SigningDate: undefined,
        })

        watch(formState, () => {
            if (formState.IsQualified === true) {
                formState.UnqualifiedItems = ''  // 这个是没问题的，浏览器里的vue开发工具更新不及时而已，重启一下vue开发工具即可发现变成空串了
            }
        }, { deep: true })

        const addDeflection = () => {
            formState.Items.push({
                SpecifiedValueAndAllowableDeviation: '',
                InspectionResult: '',
                Code: '',
                Note: '',
            })
        }

        const deleteDeflection = () => {
            formState.Items.splice(formState.Items.length - 1, 1)
        }

        // 可以用表单组件自带的校验，但一个一个弄太麻烦了，我为了调样式用了很多个<a-form>，就牺牲点数据校验方面的用户体验吧
        // 反正后端也做数据校验了，非法数据是不可能有的
        const validateFormState = (): boolean => {
            let isValid = true
            if (formState.ExpresswayName === '') {
                message.error('高速公路名为必填项')
                isValid = false
            }
            if (formState.ContractNumber === '') {
                message.error('承包单位为必填项')
                isValid = false
            }
            if (formState.SupervisionCompany === '') {
                message.error('监理单位为必填项')
                isValid = false
            }
            if (formState.ContractNumber === '') {
                message.error('合同号为必填项')
                isValid = false
            }
            if (formState.SerialNumber === '') {
                message.error('编号为必填项')
                isValid = false
            }
            if (formState.SubgradeType === SubgradeType.Unset) {
                message.error('请选择路基类型')
                isValid = false
            }
            if (formState.ProjectName === '') {
                message.error('工程名称为必填项')
                isValid = false
            }
            if (formState.StakeNumberAndLocation === '') {
                message.error('桩号及部位为必填项')
                isValid = false
            }
            if (formState.StartDate === undefined) {
                message.error('请选择施工时间')
                isValid = false
            }
            if (formState.InspectionDate === undefined) {
                message.error('请选择检验时间')
                isValid = false
            }
            if (formState.IsQualified === undefined) {
                message.error('监理意见为必填项')
                isValid = false
            }
            if (formState.IsQualified === false && formState.UnqualifiedItems === '') {
                message.error('若不合格，必须填写不合格项')
                isValid = false
            }
            if (formState.SupervisorName === '') {
                message.error('监理姓名为必填项')
                isValid = false
            }
            if (formState.SigningDate === undefined) {
                message.error('请选择监理签字日期')
                isValid = false
            }
            for (let i = 0; i < formState.Items.length; i++) {
                const element = formState.Items[i];
                if (element.SpecifiedValueAndAllowableDeviation === '') {
                    message.error('规定值或允许偏差为必填项')
                    isValid = false
                    break
                }
            }
            for (let i = 0; i < formState.Items.length; i++) {
                const element = formState.Items[i];
                if (element.InspectionResult === '') {
                    message.error('检查结果为必填项')
                    isValid = false
                    break
                }
            }
            for (let i = 0; i < formState.Items.length; i++) {
                const element = formState.Items[i];
                if (element.Code === '') {
                    message.error('检验结果附表代码为必填项')
                    isValid = false
                    break
                }
            }
            return isValid
        }

        const handleSubmit = () => {
            const isValid = validateFormState()
            if (isValid) {
                submitButtonIsLoading.value = true;
                submit(formState)
                    .then(response => {
                        showSuccessModalAndReload("提交成功")
                    })
                    .catch(error => {
                        showErrorModal(`提交失败：${error.response.data}`)
                        submitButtonIsLoading.value = false
                    })
                    
            }
        }

        return {
            arr,
            locale,
            radioStyle,
            isQualified,
            constructionDateRange,
            inspectionDate,
            supervisionDate,
            formState,
            submitButtonIsLoading,
            addDeflection,
            deleteDeflection,
            handleSubmit
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

#button-submit {
    margin-top: 100px;
    font-size: 30px;
    width: 200px;
    height: 50px;
    padding-bottom: 55px;
}
</style>
