export default interface ApiResponse<T> {
  succeeded: boolean;
  result: T;
  errors: string[],
  infoMessages: string[]
}