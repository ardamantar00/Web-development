import { useContext, useEffect, useState } from "react";
import { useNavigate } from "react-router";
import { ThemeContext } from "../contexts/ThemeContext";
import {Autocomplete,TextField} from '@mui/material';
import axios from "axios";

const api_url = "https://api.themoviedb.org/3";
const api_key = import.meta.env.VITE_API_KEY;
const language  = "tr-TR";
export default function SearchForm() {

  const [searchQuery, setSearchQuery] = useState("");
  const [movieSuggestions,setMovieSuggestions] = useState([]);
  const navigate = useNavigate();
  const { theme } = useContext(ThemeContext);
  const textColor = theme === "dark" ? "light" : "dark";

  useEffect(()=>{
    const fetchSuggestions = async()=>{
      if(searchQuery.length>2){
        try{
          const response = await axios.get(`${api_url}/search/movie`,{
             params: {
              api_key,
              query: searchQuery,
              language,
              page : 1,
            },
          });
          setMovieSuggestions(response.data.results.map(movie=>movie.title))
        }catch(error){
           console.error("Error fetching movie suggestions:", error);
        }
      }
      else{
        setMovieSuggestions([])
      }
    }
    fetchSuggestions();
  },[searchQuery])

  function handleSubmit(e) {
    e.preventDefault();
    const query = searchQuery.trim();

    if (query) {
      navigate(`/search?q=${encodeURIComponent(query)}`);
      setSearchQuery("");
    }
  }
  return (
    <form className="d-flex mb-2 mb-lg-0" onSubmit={handleSubmit}>
     <Autocomplete sx={{
    width: {
      xs: "100%",   
      sm: "300px",  
      md: "400px",  
      lg: "500px",  
    }
  }}
      onChange={(e,value)=>{
        if(value){
          navigate(`/search?q=${encodeURIComponent(value)}`);
          setSearchQuery("")
        }
      }}
     value={searchQuery}
     onInputChange={(e,newValue)=>setSearchQuery(newValue)}
     options={movieSuggestions}
     renderInput={(params)=>(
      <TextField
            {...params}
            label="Search Movies"
            variant="outlined"
            fullWidth
            color="info"
          />
     )}
     />
      <button className={`btn btn-${theme} border`} type="submit">
        <i className="bi bi-search"></i>
      </button>
    </form>
  );
}
