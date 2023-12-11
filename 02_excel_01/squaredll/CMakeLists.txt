cmake_minimum_required(VERSION 3.15)
project(squaredll CXX)



add_executable(squaredll src/squaredll.cpp src/main.cpp)



install(TARGETS squaredll DESTINATION "."
        RUNTIME DESTINATION bin
        ARCHIVE DESTINATION lib
        LIBRARY DESTINATION lib
        )
