<template>
  <v-layout
    class="container-layout centered-container d-flex flex-column justify-space-between pb-5">
    <section
      class="filters-container bg-secondary w-100 py-10 rounded-b-xl d-flex flex-column elevation-7">
      <article class="mx-auto w-100 d-flex flex-column ga-10" style="max-width: 20rem">
        <div>
          <label for="date" class="text-h6 font-weight-bold">Data:</label>
          <v-text-field
            id="date"
            variant="outlined"
            base-color="primary"
            width="100%"
            type="date"
            hide-details
            class="mx-auto" />
        </div>
        <v-divider />
        <div>
          <span class="text-h6 font-weight-bold">Status:</span>
          <v-checkbox
            false-icon="mdi-checkbox-blank-outline"
            true-icon="mdi-checkbox-marked-outline"
            label="Concluída"
            density="compact"
            hide-details />
          <v-checkbox
            false-icon="mdi-checkbox-blank-outline"
            true-icon="mdi-checkbox-marked-outline"
            label="Não concluída"
            density="compact"
            hide-details />
        </div>
      </article>
    </section>
    <div class="d-flex w-100">
      <v-btn class="mx-auto w-50" rounded="pill" flat variant="outlined">Pesquisar</v-btn>
    </div>
  </v-layout>
</template>

<script setup lang="ts"></script>

<style scoped>
.filters-container {
  width: 20rem;
}
</style>
