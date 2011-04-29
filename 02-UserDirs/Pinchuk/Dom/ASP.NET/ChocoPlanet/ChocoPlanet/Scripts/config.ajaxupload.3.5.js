$(document).ready(function() {
    new AjaxUpload($('#file_upload_button'),
        {
            // Отправляем 
            autoSubmit: true,               // Отправлять ли файл сразу после выбора
            action: '/File/UploadFiles',    // Куда отправлять
            name: 'myfile',                 // Имя переменной для хранения файла.
            response: 'json',               // Ответ сервера.

            // Срабатывает перед загрузкой файла
            // Тоже можно вернуть false для отмены.
            onSubmit: function(file, extension) {
                // Скрываем "кнопку" выбора файла.
                $('#file_upload_button').hide();
                // Показываем сообщение о загрузке.
                $('#uploading').show();
                //Если надо загрузить только один файл:
                //this.disable();
            },

            // Выполняется после получения ответа от сервера.
            // file - имя файла, который указал клиент.
            // response - ответ сервера.
            onComplete: function(file, response) {
                $('#file_upload_button').show();
                $('#uploading').hide();

                // Получаем javascript-объект.
                var resultObject = eval('(' + response + ')');

                // Добавляем новые загруженные файлы к общему списку.
                if (resultObject.collection.length > 0) {
                    $.each(resultObject.collection, function(i) {
                        $('.files').append('<li>' + this + '</li>');
                    });
                }
            }
        });
});