<template>
  <a-table :columns="columns" :row-key="(record: any) => record.id" :data-source="dataSource" :pagination="pagination"
    :loading="loading" :custom-row="customRow" @change="handleTableChange">
    <template #bodyCell="{ column, text }">
      <template v-if="column.dataIndex === 'name'">{{ text.first }} {{ text.last }}</template>
    </template>
  </a-table>
  <FullModal ref="fullModalRef" />
</template>
<script lang="ts">
import type { TableProps } from 'ant-design-vue';
import { usePagination } from 'vue-request';
import { computed, defineComponent, ref } from 'vue';
import axios from 'axios';
import FullModal from './FullModal.vue';
const columns = [
  {
    title: 'Id',
    dataIndex: 'id',
    width: '30%',
  },
  {
    title: '工程名称',
    dataIndex: 'projectName',
    width: '30%',
  },
  {
    title: '监理工程师',
    dataIndex: 'supervisorName',
  },
  {
    title: '提交时间',
    dataIndex: 'submitTime',
    // width: '30%'
  },
];

type APIParams = {
  pageSize: number;
  page?: number;
  sortField?: string;
  sortOrder?: number;
  [key: string]: any;
};
type APIResult = {
  results: {
    id: string;
    projectName: string;
    isQualified: boolean;
    submitTime: string;
  }[];
};

export default defineComponent({
  components: {
    FullModal
  },
  props: {
    status: {
      required: true,
      type: String,
    }
  },
  setup(props) {
    const queryData = (params: APIParams) => {
      return axios.get<APIResult>(`https://localhost:7233/api/Form/PaginatlyGetFormInfosInStatus/isQualified/${props.status}`, { params });
    };
    const {
      data: dataSource,
      run,
      loading,
      current,
      pageSize,
    } = usePagination(queryData, {
      formatResult: (res: any) => res.data,
      pagination: {
        currentKey: 'page',
        pageSizeKey: 'pageSize',
      },
    });

    const pagination = computed(() => ({
      total: 200,
      current: current.value,
      pageSize: pageSize.value,
    }));

    const handleTableChange: TableProps['onChange'] = (
      pag: { pageSize: number; current: number },
    ) => {
      run({
        pageSize: pag.pageSize!,
        page: pag?.current,
      });
    };

    const fullModalRef = ref<InstanceType<typeof FullModal>>()
    const customRow = (record: any) => {
      return {
        onClick: () => {
          fullModalRef.value?.showModal(record.id)
        },
      };
    };

    return {
      dataSource,
      pagination,
      loading,
      columns,
      fullModalRef,
      handleTableChange,
      customRow
    };
  },
});
</script>
  
  