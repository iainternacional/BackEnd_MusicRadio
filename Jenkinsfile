pipeline {
    agent any

    stages {
        stage('Clonar código') {
            steps {
                echo 'Código ha sido clonado por Jenkins.'
            }
        }

        stage('Construir imagen Docker') {
            steps {
                dir('MusicRadio.BackEnd.WebApi') {
                    script {
                        dockerImage = docker.build('musicradio-backend:latest')
                    }
                }
            }
        }

        stage('Correr contenedor') {
            steps {
                sh 'docker run -d -p 8080:8080 --name musicradio-container musicradio-backend:latest'
            }
        }
    }

    post {
        always {
            echo 'Pipeline terminado'
        }
    }
}
