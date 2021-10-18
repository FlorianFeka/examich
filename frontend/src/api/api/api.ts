export * from './auth.service';
import { AuthService } from './auth.service';
export * from './exams.service';
import { ExamsService } from './exams.service';
export * from './users.service';
import { UsersService } from './users.service';
export * from './weatherForecast.service';
import { WeatherForecastService } from './weatherForecast.service';
export const APIS = [AuthService, ExamsService, UsersService, WeatherForecastService];
