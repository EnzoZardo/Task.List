export {}

declare global {
  interface Date {
    addDays(days: number): Date
    toInputDate(): string
    getLocale(): string
    getRealMonth(): number
    getDateWithUTC(): Date
    toVDatePicker(): string
  }
}

Date.prototype.addDays = function (days: number = 1): Date {
  return new Date(this.getFullYear(), this.getMonth(), this.getDate() + days, this.getHours())
}

Date.prototype.toInputDate = function (): string {
  return this.toISOString().split('T')[0]
}

type DateTimeFormatOptions = {
  weekday: "long"
  month: "numeric"
  day: "numeric"
}

Date.prototype.getLocale = function (): string {
  const options: DateTimeFormatOptions = {
    weekday: "long",
    month: "numeric",
    day: "numeric",
  };

  return this.toLocaleDateString("pt-BR", options)
}

Date.prototype.getRealMonth = function (): number {
  return this.getMonth() + 1
}

Date.prototype.getDateWithUTC = function (): Date {
  return new Date(
    this.getUTCFullYear(),
    this.getUTCMonth(),
    this.getUTCDay(),
  )
}

Date.prototype.toVDatePicker = function (): string {
  return this.toISOString().substring(0, 10)
}