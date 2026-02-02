<template>
  <v-navigation-drawer
    location="top"
    class="rounded-b-lg centered-container"
    rail
    rail-width="80"
    v-model="openTopDrawer">
    <div class="d-flex align-center justify-end pa-3 w-100 ga-3">
      <v-divider />
      <v-btn variant="outlined" icon="mdi-calendar" @click="openDatePicker = !openDatePicker" />
      <v-btn variant="outlined" icon="mdi-filter-outline" :to="{ name: 'filters' }" />
    </div>
  </v-navigation-drawer>
  <v-layout class="container-layout centered-container">
    <v-card class="w-100" color="transparent" flat>
      <v-card-title class="d-flex flex-row align-start justify-space-between py-5 px-6">
        <div>
          <p class="text-title-1 font-weight-bold">{{ title }}</p>
        </div>
        <div class="d-flex ga-2">
          <v-btn variant="outlined" icon="mdi-plus" />
          <v-btn
            variant="outlined"
            icon="mdi-chevron-down"
            @click="openTopDrawer = !openTopDrawer" />
        </div>
      </v-card-title>
    </v-card>
    <date-slider v-model="selectedDate" :range />
    <v-container class="timeline-wrapper bg-primary py-0 rounded-t-xl h-100 px-0">
      <v-timeline side="end" align="center" class="container-timeline timeline-scroll">
        <v-timeline-item
          v-for="item in items"
          :key="item.id"
          class="overflow-y-auto"
          size="small"
          dot-color="secondary">
          <template v-slot:icon><v-icon @click="title += `${item.id}`"></v-icon></template>
          <v-card
            @click="toggleTask(item.id)"
            color="secondary"
            rounded="xl"
            :elevation="selectedTasks.includes(item.id) ? 5 : 1"
            class="text-background">
            <v-card-title class="text-background"> Titulo </v-card-title>
            <v-card-text class="text-background">
              Lorem ipsum dolor sit amet, no nam oblique veritus. Commune scaevola imperdiet nec ut,
              sed euismod convenire principes at. Est et nobis iisque percipit, an vim zril
              disputando voluptatibus, vix an salutandi sententiae.
            </v-card-text>
          </v-card>
        </v-timeline-item>
      </v-timeline>
    </v-container>
  </v-layout>
  <v-dialog v-model="openDatePicker" :fullscreen="xs">
    <v-date-picker
      v-model="selectedDate"
      @update:model-value="
        () => {
          openDatePicker = false
          openTopDrawer = false
        }
      "
      title="Escolha a data"
      locale="pt"
      header="Selecione"
      class="mx-auto" />
  </v-dialog>
</template>

<script setup lang="ts">
import _isMobile from '@/tools/isMobile'
import { computed, reactive, ref } from 'vue'
import { useDisplay } from 'vuetify'

const range = 15
const { xs } = useDisplay()

const selectedDate = ref(new Date())
const openTopDrawer = ref(false)
const openDatePicker = ref(false)

const selectedTasks = reactive<number[]>([])

const toggleTask = (id: number) => {
  if (!selectedTasks.includes(id)) {
    selectedTasks.push(id)
    return
  }
  const index = selectedTasks.indexOf(id)
  selectedTasks.splice(index, 1)
}

const title = computed(() => selectedDate.value.getLocale().capitalizeAll())

const items = [
  {
    id: 1,
    color: 'info',
    icon: 'mdi-information',
  },
  {
    id: 2,
    color: 'error',
    icon: 'mdi-alert-circle',
  },
  {
    id: 2,
    color: 'error',
    icon: 'mdi-alert-circle',
  },
  {
    id: 2,
    color: 'error',
    icon: 'mdi-alert-circle',
  },
  {
    id: 2,
    color: 'error',
    icon: 'mdi-alert-circle',
  },
  {
    id: 2,
    color: 'error',
    icon: 'mdi-alert-circle',
  },

  {
    id: 2,
    color: 'error',
    icon: 'mdi-alert-circle',
  },
  {
    id: 2,
    color: 'error',
    icon: 'mdi-alert-circle',
  },
  {
    id: 2,
    color: 'error',
    icon: 'mdi-alert-circle',
  },
]
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
