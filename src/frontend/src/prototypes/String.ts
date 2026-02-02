export {}

declare global {
  interface String {
    capitalize(): String
    capitalizeAll(): String
  }
}

const SPACE = ' '

String.prototype.capitalize = function (): string {
  return this.slice(0, 1).toLocaleUpperCase() + this.slice(1).toLocaleLowerCase()
}

String.prototype.capitalizeAll = function (): string {
  return this.split(SPACE)
    .map((x) => x.capitalize())
    .join(SPACE)
}
