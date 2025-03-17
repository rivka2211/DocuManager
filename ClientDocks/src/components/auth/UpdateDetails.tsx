import { ChangeEvent, useContext, useState } from "react";
import { UserContext } from "./UserReducer";
import { Modal, Box, Grid2 as Grid, TextField, Button } from "@mui/material";
import axios from "axios";

const style1 = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 300,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

const UpdateDetails = () => {
  let [state, dispatch] = useContext(UserContext);
  const [open, setOpen] = useState(false);
  const [formData, setFormData] = useState(state);

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { id, value } = e.target;
    setFormData({ ...formData, [id]: value });
  };
  const handleClick = async () => {
    const url = 'http://localhost:3000/api/user';
    try {
      const res = await axios.put(url, formData, { headers: { "user-id": state.id.toString() } });
      console.log(res.data);
      dispatch({
        type: 'UPDATE',
        data: formData
      })
    } catch (error) {
      console.error(error);
    }
    setOpen(false);};

  return (
    <>
      <Button color="primary" variant="outlined" onClick={() => setOpen(true)}>Update</Button>
      {open &&
        <Modal open={open} onClose={() => setOpen(false)}>
          <Box sx={style1} component="form" >
            <Grid container rowSpacing={1} >
              <TextField id="firstName" label='First Name' defaultValue={state.firstName} onChange={handleChange} />
              <TextField id="lastName" label='Last Name' defaultValue={state.lastName} onChange={handleChange} />
              <TextField id="email" label='Email' defaultValue={state.email} onChange={handleChange} type="email" />
              <TextField id="address" label='Address' defaultValue={state.address} onChange={handleChange} />
              <TextField id="password" label='Password' defaultValue={state.password} onChange={handleChange} type="password" />
              <TextField id="phone" label='phone Number' defaultValue={state.phone} onChange={handleChange} />
              {/*size={6}*/}
              <Grid >
                <Button onClick={handleClick}>Update</Button>
              </Grid>
            </Grid>
          </Box>
        </Modal>}

    </>
  );
}
export default UpdateDetails