let books = [];
let authors = [];
let idSelected;
const ul = document.querySelector("ul");
const bookForm = document.getElementById("bookForm");
const loginForm = document.getElementById("loginForm");
const deleteButton = document.getElementById("deleteButton");
const cancelButton = document.getElementById("cancelButton");
const saveButton = document.getElementById("saveButton");

async function init() {
  loginForm.addEventListener("submit", logIn);
  cancelButton.addEventListener("click", clearSelection);
  bookForm.addEventListener("submit", saveBook);
  deleteButton.addEventListener("click", deleteBook);

  if (isLoggedIn()) {
    showBooksScreen();
  } else {
    showLoginScreen();
  }
}
init();

function showLoginScreen() {
  document.getElementById("booksScreen").style.display = "none";
  document.getElementById("loginScreen").style.display = "block";
}

async function showBooksScreen() {
  document.getElementById("booksScreen").style.display = "block";
  document.getElementById("loginScreen").style.display = "none";
  document.body.style.backgroundImage = "url()";
  [books, authors] = await Promise.all([listBooks(), listAuthors()]);
  showAuthorsOptions();
  showBooks();
  clearSelection();
}

async function logIn(evt) {
  evt.preventDefault();
  try {
    await login(loginForm.email.value, loginForm.password.value);
    showBooksScreen();
  } catch (erro) {
    showError("Falha no login. Verifique e-mail e senha.");
  }
}

function selectItem(book, li) {
  clearSelection();
  idSelected = book.id;
  li.classList.add("selected");
  bookForm.title.value = book.title;
  bookForm.isbn.value = book.isbn;
  bookForm.authorId.value = book.authorId;
  bookForm.publishingYear.valueAsNumber = book.publishingYear;
  deleteButton.style.display = "inline";
  cancelButton.style.display = "inline";
  saveButton.textContent = "Atualizar";
}

function clearSelection() {
  clearErrors();
  idSelected = undefined;
  const li = ul.querySelector(".selected");
  if (li) {
    li.classList.remove("selected");
  }
  bookForm.title.value = "";
  bookForm.isbn.value = "";
  bookForm.authorId.value = "";
  bookForm.publishingYear.value = "";
  deleteButton.style.display = "none";
  cancelButton.style.display = "none";
  saveButton.textContent = "Cadastrar";
}

async function saveBook(evt) {
  evt.preventDefault();
  const bookPayload = {
    id: idSelected,
    title: bookForm.title.value,
    isbn: +bookForm.isbn.value,
    authorId: +bookForm.authorId.value,
    publishingYear: bookForm.publishingYear.valueAsNumber,
  };
  if (
    !bookPayload.title ||
    !bookPayload.isbn ||
    !bookPayload.authorId ||
    !bookPayload.publishingYear
  ) {
    showError("Prencha todos os campos.");
  } else {
    if (idSelected) {
      await updateBook(bookPayload);
    } else {
      await createBook(bookPayload);
    }
    books = await listBooks();
    showBooks();
  }
}

async function deleteBook() {
  if (idSelected) {
    await removeBook(idSelected);
    books = await listBooks();
    clearSelection();
    showBooks();
  }
}

function showBooks() {
  ul.innerHTML = "";
  for (const book of books) {
    const li = document.createElement("li");
    const divTitle = document.createElement("div");
    divTitle.textContent = book.title;
    li.appendChild(divTitle);
    const divAuthor = document.createElement("div");
    console.log(book.author)
    divAuthor.textContent = book.author.name + " " + book.author.lastName;
    li.appendChild(divAuthor);
    const divPublishingYear = document.createElement("div");
    divPublishingYear.textContent = book.publishingYear;
    li.appendChild(divPublishingYear);
    ul.appendChild(li);
    if (idSelected === book.id) {
      li.classList.add("selected");
    }
    li.addEventListener("click", () => selectItem(book, li));
  }
}

function showAuthorsOptions() {
  bookForm.authorId.innerHTML = "";
  for (const author of authors) {
    const option = document.createElement("option");
    option.textContent = author.name + " " + author.lastName;
    option.value = author.id;
    bookForm.authorId.appendChild(option);
  }
}

function showError(message, error) {
  document.getElementById("errors").textContent = message;
  if (error) {
    console.error(error);
  }
}

function clearErrors() {
  document.getElementById("errors").textContent = "";
}
