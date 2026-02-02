<template>
  <div class="d-flex my-2 ga-2 align-center" style="max-width: 100%">
    <v-btn
      @click="backwardDate"
      icon="mdi-chevron-left"
      color="background"
      flat
      density="compact"
      :ripple="false" />
    <div class="d-flex pa-3 ga-2 h-100 justify-center" style="max-width: 100%; overflow: hidden">
      <template v-for="(date, index) in dates" :key="index">
        <v-btn
          v-if="isSelectedDate(date)"
          elevation="5"
          class="font-weight-bold"
          :class="{
            'scale-1-2': loadingCurrentDate,
          }"
          color="tertiary"
          rounded="pill"
          height="100%"
          size="large"
          :loading="loadingCurrentDate"
          flat>
          {{ computedSelectedDate }}
        </v-btn>

        <v-btn
          v-else
          elevation="3"
          @click="specificDate(date)"
          rounded="circle"
          color="quartenary"
          class="opacity-60"
          icon
          flat>
          {{ date.getDate() }}
        </v-btn>
      </template>
    </div>
    <v-btn
      @click="forwardDate"
      rounded="lg"
      icon="mdi-chevron-right"
      color="background"
      flat
      density="compact"
      :ripple="false" />
  </div>
</template>

<script setup lang="ts">
import { computed, reactive, watch } from 'vue'

const props = defineProps<{
  range: number
  loadingCurrentDate?: boolean
}>()

const createDateArray = (date: Date, length: number) =>
  Array.from({ length }, (_, i) => date.addDays(Math.trunc(-length / 2) + i))

let dates = reactive(createDateArray(new Date(), props.range))
const model = defineModel<Date>({ default: new Date() })

const computedSelectedDate = computed(() => {
  const d = model.value
  return `${d.getDate().toString().padStart(2, '0')}/${d.getRealMonth().toString().padStart(2, '0')}`
})

const isSelectedDate = (date: Date) => model.value.getDate() == date.getDate()

const forwardDate = () => {
  dates.splice(0, 1)
  dates.push(dates[dates.length - 1].addDays(1))
  model.value = model.value.addDays(1)
}

const backwardDate = () => {
  dates.splice(dates.length - 1, 1)
  dates.unshift(dates[0].addDays(-1))
  model.value = model.value.addDays(-1)
}

const specificDate = (date: Date) => {
  model.value = date
  dates = createDateArray(date, props.range)
}

watch(model, () => {
  specificDate(model.value)
})
</script>

<style scoped>
.scale-1-2 {
  transition: scale 0.5s;
  scale: 1.1;
}
</style>
