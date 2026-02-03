// @ts-ignore
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import { VDateInput } from 'vuetify/labs/VDateInput'
import { pt } from 'vuetify/locale'

const theme = {
  dark: false,
  colors: {
    background: '#F5F5EC',
    backgroundSecondary: '#FFFFFF',
    primary: '#411a72',
    secondary: '#592498',
    tertiary: '#ae55e6',
    quartenary: '#df5f97',
    information: '#555555',
    error: '#B00020',
  },
}

export default createVuetify({
  components: {
    ...components,
    VDateInput
  },
  directives,
  icons: {
    defaultSet: 'mdi',
  },
  locale: {
    locale: 'pt',
    fallback: 'en',
    messages: { pt },
  },
  theme: {
    defaultTheme: 'theme',
    themes: {
      theme,
    },
  },
  defaults: {
    global: {
      ripple: false,
    },
    VCard: {
      class: 'text-information text-caption',
    }
  },
})
