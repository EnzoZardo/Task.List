<template>
  <v-layout class="container-layout centered-container">
    <v-card class="w-100" color="transparent" flat>
      <v-card-title
        class="d-flex flex-row align-start flex-wrap justify-space-between py-5 px-6"
      >
        <div>
          <p class="text-title-1 font-weight-bold">{{ title }}</p>
          <span class="text-caption"
            >Selecionadas {{ selectedTasks.length }}</span
          >
        </div>
        <div class="d-flex ga-2">
          <v-btn variant="outlined" icon="mdi-plus" @click="openCreation" />
          <v-btn
            variant="outlined"
            icon="mdi-calendar"
            @click="openDatePicker = !openDatePicker"
          />
        </div>
      </v-card-title>
    </v-card>

    <v-container
      class="timeline-wrapper bg-primary py-0 rounded-t-xl h-100 px-0"
    >
      <v-scale-transition>
        <div class="d-flex w-100 pt-3 px-5 ga-4" v-if="!xs">
          <v-btn
            rounded="pill"
            variant="outlined"
            append-icon="mdi-check-bold"
            :disabled="selectedTasks.length == 0"
            :loading="tasksRequest.isLoading"
            @click="concludeTasks"
            flat
            >Concluir</v-btn
          >
          <v-btn
            rounded="pill"
            color="quartenary"
            variant="outlined"
            append-icon="mdi-close"
            :disabled="selectedTasks.length == 0"
            @click="deleteTasks"
            :loading="tasksRequest.isLoading"
            flat
            >Excluir</v-btn
          >
          <v-btn
            rounded="pill"
            color="tertiary"
            variant="outlined"
            append-icon="mdi-pencil-outline"
            :loading="tasksRequest.isLoading"
            :disabled="
              selectedTasks.length != 1 ||
              tasks.find((x) => x.id == selectedTasks[0])?.done
            "
            @click="openEdition(selectedTasks[0] ?? 0)"
            flat
            >Editar</v-btn
          >
        </div>
        <div class="d-flex w-100 pt-3 px-5 ga-4" v-else>
          <v-btn
            rounded="pill"
            variant="outlined"
            icon="mdi-check-bold"
            :disabled="selectedTasks.length == 0"
            flat
          />
          <v-btn
            rounded="pill"
            color="quartenary"
            variant="outlined"
            icon="mdi-close"
            :disabled="selectedTasks.length == 0"
            flat
          />
          <v-btn
            rounded="pill"
            color="tertiary"
            variant="outlined"
            icon="mdi-pencil-outline"
            :disabled="selectedTasks.length != 1"
            flat
          />
        </div>
      </v-scale-transition>
      <v-timeline side="end" align="center" class="timeline-scroll w-100">
        <v-timeline-item
          v-if="tasks.length == 0"
          size="small"
          dot-color="secondary"
        >
          Sem tarefas para esta data.
        </v-timeline-item>
        <v-timeline-item
          v-for="item in tasks"
          :key="item.id"
          class="overflow-y-auto"
          size="small"
          :dot-color="
            selectedTasks.includes(item.id!) ? 'tertiary' : 'secondary'
          "
        >
          <template v-slot:icon>
            <v-icon v-if="item.done">mdi-check</v-icon>
          </template>
          <v-card
            @click="toggleTask(item.id!)"
            :color="selectedTasks.includes(item.id!) ? 'tertiary' : 'secondary'"
            rounded="xl"
            :elevation="selectedTasks.includes(item.id!) ? 10 : 1"
            class="text-background"
          >
            <v-card-title class="text-background">
              {{ item.title }}
            </v-card-title>
            <v-card-text class="text-background">
              {{ item.description }}
            </v-card-text>
          </v-card>
        </v-timeline-item>
      </v-timeline>
    </v-container>
  </v-layout>
  <v-bottom-sheet
    class="centered-container w-100"
    :model-value="isCreating || isEditing"
    persistent
  >
    <v-card class="rounded-t-xl" color="tertiary">
      <v-card-title
        class="text-h5 font-weight-bold text-white d-flex align-center px-7"
      >
        Atividade
        <v-spacer />
        <v-btn icon="mdi-close" variant="text" @click="closeTaskSheet" />
      </v-card-title>
      <div class="pa-6 d-flex flex-column ga-4">
        <v-date-input
          label="Data da tarefa"
          variant="outlined"
          class="text-white"
          color="white"
          base-color="white"
          hide-details
          v-model="taskSheet.releaseDateTime"
          @update:model-value="console.log"
        />
        <v-text-field
          label="Titulo"
          placeholder="Alimentar o meu gato"
          variant="outlined"
          class="text-white"
          color="white"
          base-color="white"
          hide-details
          maxlength="40"
          v-model="taskSheet.title"
        />
        <v-textarea
          label="Descrição"
          placeholder="Acordar as 3h da tarde para alimentar o gatinho..."
          variant="outlined"
          class="text-white"
          color="white"
          base-color="white"
          hide-details
          maxlength="250"
          v-model="taskSheet.description"
        />
      </div>
      <v-card-actions tag="div" class="d-flex justify-center">
        <v-btn
          color="primary"
          rounded="xl"
          variant="outlined"
          class="application-btn"
          max-width="13rem"
          @click="closeTaskSheet"
          >Cancelar</v-btn
        >
        <v-btn
          color="white"
          rounded="xl"
          variant="outlined"
          class="application-btn"
          max-width="13rem"
          v-if="isCreating"
          :disabled="!hasAllTaskFields"
          :loading="tasksRequest.isLoading"
          @click="createTask"
          >Salvar</v-btn
        >
        <v-btn
          color="white"
          rounded="xl"
          variant="outlined"
          class="application-btn"
          max-width="13rem"
          :loading="tasksRequest.isLoading"
          :disabled="!hasAllTaskFields"
          @click="editTask"
          v-else
          >Editar</v-btn
        >
      </v-card-actions>
    </v-card>
  </v-bottom-sheet>
  <v-dialog v-model="openDatePicker" :fullscreen="xs">
    <v-date-picker
      v-model="selectedDate"
      @update:model-value="selectDate"
      title="Escolha a data"
      locale="pt"
      header="Selecione"
      class="mx-auto"
    />
  </v-dialog>
</template>

<script setup lang="ts">
import _axios from "@/plugins/axios";
import router from "@/router";
import _isMobile from "@/tools/isMobile";
import Requester from "@/types/Requester";
import type { CreateUserTask, UserTask } from "@/types/Tasks/UserTask";
import { computed, reactive, ref, watch } from "vue";
import { useRoute } from "vue-router";
import { useDisplay } from "vuetify";

const route = useRoute();
const { xs } = useDisplay();
const tasksRequest = reactive(Requester.Create<UserTask[]>(_axios));

let locale = new Date().getDateWithUTC();
if (route.query.date) {
  locale = new Date(route.query.date as string);
}

const selectedDate = ref(locale);
const openDatePicker = ref(false);
const isCreating = ref(false);
const isEditing = ref(false);
const tasks = ref<UserTask[]>([]);
const selectedTasks = reactive<number[]>([]);
const taskSheet = reactive<CreateUserTask>({
  title: "",
  description: "",
  releaseDateTime: new Date().toVDatePicker(),
});
const title = computed(() => selectedDate.value.getLocale().capitalizeAll());

const toggleTask = (id: number) => {
  if (!selectedTasks.includes(id)) {
    selectedTasks.push(id);
    return;
  }
  const index = selectedTasks.indexOf(id);
  selectedTasks.splice(index, 1);
};

const openEdition = (id: number) => {
  const item = tasks.value.find((x) => x.id == id);
  if (item) {
    isEditing.value = true;
    setTaskSheet({
      ...item,
      releaseDateTime: item.releaseDateTime.toVDatePicker(),
    });
    return;
  }
  isCreating.value = true;
  clearTaskSheet();
};

const clearTaskSheet = () => {
  taskSheet.title = "";
  taskSheet.description = "";
  taskSheet.releaseDateTime = new Date().toVDatePicker();
};

const setTaskSheet = (item: CreateUserTask) => {
  taskSheet.title = item.title;
  taskSheet.description = item.description;
  taskSheet.releaseDateTime = item.releaseDateTime;
};

const selectDate = () => {
  openDatePicker.value = false;
  //@ts-ignore
  router.push({ query: { date: selectedDate.value } });
  selectedTasks.length = 0;
  request(selectedDate.value);
};

const openCreation = () => {
  isCreating.value = true;
  clearTaskSheet();
};

const createTask = () => {
  const data: UserTask = {
    title: taskSheet.title,
    description: taskSheet.description,
    releaseDateTime: new Date(taskSheet.releaseDateTime),
    createdDateTime: new Date().getDateWithUTC(),
    done: false,
  };

  tasksRequest.request({
    method: "POST",
    url: "/api/Tasks",
    data,
    onSuccess() {
      request(selectedDate.value);
      clearTaskSheet();
      isCreating.value = false;
    },
  });
};

const deleteTasks = () => {
  if (selectedTasks.length > 1) {
    tasksRequest.request({
      method: "DELETE",
      url: "/api/Tasks/Bulk",
      params: {
        ids: selectedTasks,
      },
      onSuccess() {
        request(selectedDate.value);
        selectedTasks.length = 0;
      },
    });
    return;
  }

  tasksRequest.request({
    method: "DELETE",
    url: `/api/Tasks/${selectedTasks[0]}`,
    onSuccess() {
      request(selectedDate.value);
      selectedTasks.length = 0;
    },
  });
};

const editTask = () => {
  const taskId = selectedTasks[0];
  const task = tasks.value.find((x) => x.id == taskId);

  if (task) {
    tasksRequest.request({
      method: "PUT",
      url: `/api/Tasks/${taskId}`,
      data: {
        ...task,
        ...taskSheet,
      },
      onSuccess() {
        request(selectedDate.value);
        selectedTasks.length = 0;
      },
    });
  }
};

const concludeTasks = () => {
  if (selectedTasks.length > 1) {
    tasksRequest.request({
      method: "PATCH",
      url: "/api/Tasks/Bulk/Conclude",
      params: {
        ids: selectedTasks,
      },
      onSuccess() {
        request(selectedDate.value);
        selectedTasks.length = 0;
      },
    });
    return;
  }

  tasksRequest.request({
    method: "PATCH",
    url: `/api/Tasks/Conclude/${selectedTasks[0]}`,
    onSuccess() {
      request(selectedDate.value);
      selectedTasks.length = 0;
    },
  });
};

const closeTaskSheet = () => {
  isCreating.value = false;
  isEditing.value = false;
};

const hasAllTaskFields = computed(
  () =>
    !!taskSheet.title && !!taskSheet.description && !!taskSheet.releaseDateTime,
);

const request = (date: Date) => {
  tasksRequest.request({
    url: "/api/Tasks",
    params: {
      specificReleaseDateTime: date,
    },
    onSuccess() {
      if (tasksRequest.response) {
        tasks.value = tasksRequest.response;
      }
    },
  });
};

const build = () => request(selectedDate.value);

build();
</script>

<style scoped>
.timeline-wrapper {
  flex: 1;
  overflow: hidden;
}

.timeline-scroll {
  height: 100%;
  overflow-y: auto;
}

.timeline-scroll::-webkit-scrollbar {
  width: 10px;
  height: 10px;
}

.timeline-scroll::-webkit-scrollbar-thumb {
  background: transparent;
  border-radius: 5px;
}

.timeline-scroll::-webkit-scrollbar-button:hover {
  background-color: #999;
}

.selected-date {
  transition: all 1s;
}
</style>
